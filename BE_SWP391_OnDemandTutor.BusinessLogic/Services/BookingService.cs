using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Booking;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.Booking;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Mapster;
using System.Linq.Dynamic.Core;
using OnDemandTutor.DataAccess.ExceptionModels;
using BE_SWP391_OnDemandTutor.Common.Paging;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.User;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface IBookingService
    {
        Task<BookingViewModel> UpdateBooking(int bookingId, UpdateBookingViewModel bookingUpdate);
        Task<BookingViewModel> UpdateBookingStatus(int bookingId, string stauts);
        Task<BookingViewModel> CreateBooking(CreateBookingRequestModel bookingCreate);
        Task<BookingViewModel> GetById(int bookingId);
        Task<BookingDetailViewModel> GetDetailById(int bookingId);
        Task<bool> DeleteBooking(int bookingId);
        Task<List<BookingDetailViewModel>> GetAllBooking(PagingSizeModel paging);
        Task<List<BookingDetailViewModel>> GetBookingByTutorId(int tutorId);
        Task<List<BookingDetailViewModel>> GetBookingByStudentId(int studentId);
        Task<bool> CancelBookingAsync(int bookingId, string cancellationReason, string status);
    }
    public class BookingService : IBookingService
    {
        private readonly BE_SWP391_OnDemandTutorDbContext _context;
        private readonly IUserService _userService;
        private readonly IClassService _classService;

        public BookingService(BE_SWP391_OnDemandTutorDbContext context, IUserService userService, IClassService classService)
        {
            _context = context;
            _userService = userService;
            _classService = classService;
        }
        public async Task<BookingViewModel> CreateBooking(CreateBookingRequestModel bookingCreate)
        {
            var booking = new Booking()
            {
                UserId = bookingCreate.UserId,
                Address = bookingCreate.Address,
                Description = bookingCreate.Description,
                EndDate = bookingCreate.EndDate,
                ScheduleId = bookingCreate.ScheduleId,
                StartDate = bookingCreate.StartDate,
            };
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return booking.Adapt<BookingViewModel>();
        }

        public async Task<bool> DeleteBooking(int idTmp)
        {
            var delete = await _context.Bookings.FindAsync(idTmp);
            if (delete == null)
            {
                return false;
            }

            _context.Bookings.Remove(delete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<BookingDetailViewModel>> GetAllBooking(PagingSizeModel paging)
        {
            // Fetch all bookings with related entities
            var bookings = await _context.Bookings
                .Include(b => b.Schedule)
                .ThenInclude(s => s.Class)
                .Include(b => b.User)
                .ToListAsync();
            var pagedBookings = bookings.Skip((paging.Page - 1) * paging.Limit).Take(paging.Limit).ToList();

            var bookingDetailViewModels = new List<BookingDetailViewModel>();

            foreach (var booking in pagedBookings)
            {
                var bookingDetail = booking.Adapt<BookingDetailViewModel>();
                var _class = await _classService.GetById(booking.Schedule.ClassID);
                bookingDetail.Class = _class.Adapt<BookingClassViewModel>();
                var tutor = await _userService.GetTutorById(booking.Schedule.Class.TutorId);
                bookingDetail.Tutor = tutor.Adapt<TutorViewModel>();
                bookingDetailViewModels.Add(bookingDetail);
            }

            return bookingDetailViewModels;
        }

        public async Task<List<BookingDetailViewModel>> GetBookingByTutorId(int tutorId)
        {
            var bookings = await _context.Bookings
               .Include(b => b.Schedule)
               .ThenInclude(s => s.Class)
               .ThenInclude(c => c.Tutor)
               .Include(b => b.User)
               .Where(b => b.Schedule.Class.TutorId == tutorId)
               .ToListAsync();

            var bookingDetailViewModels = new List<BookingDetailViewModel>();

            foreach (var booking in bookings)
            {
                var bookingDetail = booking.Adapt<BookingDetailViewModel>();
                var _class = await _classService.GetById(booking.Schedule.ClassID);
                bookingDetail.Class = _class.Adapt<BookingClassViewModel>();
                var tutor = await _userService.GetTutorById(booking.Schedule.Class.TutorId);
                bookingDetail.Tutor = tutor.Adapt<TutorViewModel>();
                bookingDetailViewModels.Add(bookingDetail);
            }

            return bookingDetailViewModels;

        }
        public async Task<List<BookingDetailViewModel>> GetBookingByStudentId(int studentId)
        {
            var bookings = await _context.Bookings
                .Where(b => b.UserId == studentId)
                .Include(b => b.Schedule)
                .ThenInclude(b => b.Class)
                .ThenInclude(b => b.Tutor)
                .Include(b => b.User)
                .ToListAsync();

            var bookingDetailViewModels = new List<BookingDetailViewModel>();

            foreach (var booking in bookings)
            {
                var bookingDetail = booking.Adapt<BookingDetailViewModel>();
                var _class = await _classService.GetById(booking.Schedule.ClassID);
                bookingDetail.Class = _class.Adapt<BookingClassViewModel>();
                var tutor = await _userService.GetTutorById(booking.Schedule.Class.TutorId);
                bookingDetail.Tutor = tutor.Adapt<TutorViewModel>();
                bookingDetailViewModels.Add(bookingDetail);
            }

            return bookingDetailViewModels;
        }
        public async Task<BookingViewModel> GetById(int bookingId)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.BookingId == bookingId);

            if (booking == null)
            {
                throw new NotFoundException("Can not find the Booking");
            }
            return booking.Adapt<BookingViewModel>();
        }
        public async Task<BookingDetailViewModel> GetDetailById(int bookingId)
        {
            var booking = await _context.Bookings
                .Include(b => b.Schedule)
                .ThenInclude(b => b.Class)
                .ThenInclude(b => b.Tutor)
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.BookingId == bookingId);
            if (booking == null)
            {
                throw new NotFoundException("Can not find the Booking");
            }
            var bookingDetail = booking.Adapt<BookingDetailViewModel>();
            var _class = await _classService.GetById(booking.Schedule.ClassID);
            bookingDetail.Class = _class.Adapt<BookingClassViewModel>();
            var tutor = await _userService.GetTutorById(booking.Schedule.Class.TutorId);
            bookingDetail.Tutor = tutor.Adapt<TutorViewModel>();

            return bookingDetail;
        }

        public async Task<BookingViewModel> UpdateBooking(int bookingId, UpdateBookingViewModel updateModel)
        {
            var existingModel = await _context.Bookings.FindAsync(bookingId);
            if (existingModel == null)
            {
                throw new NotFoundException("Can not find the Booking");
            }
            existingModel.Status = updateModel.Status;
            existingModel.Description = updateModel.Description;
            existingModel.Address = updateModel.Address;
            existingModel.StartDate = updateModel.StartDate;
            existingModel.EndDate = updateModel.EndDate;

            await _context.SaveChangesAsync();

            return existingModel.Adapt<BookingViewModel>();
        }
        public async Task<BookingViewModel> UpdateBookingStatus(int bookingId, string stauts)
        {
            var existingModel = await _context.Bookings.FindAsync(bookingId);
            if (existingModel == null)
            {
                throw new NotFoundException("Can not find the Booking");
            }
            existingModel.Status = stauts;

            await _context.SaveChangesAsync();

            return existingModel.Adapt<BookingViewModel>();
        }

        public async Task<bool> CancelBookingAsync(int bookingId, string cancellationReason, string status) // Ensure 'public' matches the interface
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null)
            {
                return false;
            }

            booking.CancellationReason = cancellationReason;
            booking.Status = status;
            await _context.SaveChangesAsync();

            return true;
        }

    }
}