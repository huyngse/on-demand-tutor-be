using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Booking;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Feedback;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.Booking;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Mapster;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Rate;
using System.Linq.Dynamic.Core;
using OnDemandTutor.DataAccess.ExceptionModels;

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
        Task<List<BookingDetailViewModel>> GetAllBooking();
        Task<List<BookingDetailViewModel>> GetBookingByTutorId(int tutorId);
        Task<List<BookingDetailViewModel>> GetBookingByStudentId(int studentId);
        Task<bool> CancelBookingAsync(int bookingId, string cancellationReason, string status);


    }
    public class BookingService : IBookingService
    {

        private readonly BE_SWP391_OnDemandTutorDbContext _context;

        public BookingService(BE_SWP391_OnDemandTutorDbContext context)
        {
            _context = context;
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

        public async Task<List<BookingDetailViewModel>> GetAllBooking()
        {
            var booking = await _context.Bookings
                .Include(b => b.Schedule)
                .ThenInclude(b => b.Class)
                .ThenInclude(b => b.Tutor)
                .Include(b => b.User)
                .ToListAsync();
            return booking.Select(b => b.Adapt<BookingDetailViewModel>()).ToList();
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
            return bookings.Select(b => b.Adapt<BookingDetailViewModel>()).ToList();
        
    }
        public async Task<List<BookingDetailViewModel>> GetBookingByStudentId(int studentId)
        {
            var booking = await _context.Bookings
                .Include(b => b.Schedule)
                .ThenInclude(b => b.Class)
                .ThenInclude(b => b.Tutor)
                .Include(b => b.User)
                .ToListAsync();
            return booking.Select(b => b.Adapt<BookingDetailViewModel>()).ToList();
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
            return booking.Adapt<BookingDetailViewModel>();
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

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return true;
        }


    }
}
