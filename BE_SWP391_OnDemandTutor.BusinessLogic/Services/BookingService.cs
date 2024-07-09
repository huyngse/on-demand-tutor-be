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
            return booking.Select(booking => new BookingDetailViewModel
            {
                BookingId = booking.BookingId,
                CreateDate = booking.CreateDate,
                Description = booking.Description,
                Address = booking.Address,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                Status = booking.Status,
                Schedule = new BookingScheduleViewModel
                {
                    ScheduleID = booking.ScheduleId,
                    DateOfWeek = booking.Schedule.DateOfWeek,
                    Description = booking.Schedule.Description,
                    EndTime = booking.Schedule.EndTime,
                    StartTime = booking.Schedule.StartTime,
                    Title = booking.Schedule.Title,
                },
                User = new BookingUserViewModel
                {
                    City = booking.User.City,
                    DateOfBirth = booking.User.DateOfBirth,
                    District = booking.User.District,
                    EmailAddress = booking.User.EmailAddress,
                    FullName = booking.User.FullName,
                    Gender = booking.User.Gender,
                    PhoneNumber = booking.User.PhoneNumber,
                    ProfileImage = booking.User.ProfileImage,
                    Street = booking.User.Street,
                    UserId = booking.User.UserId,
                    Username = booking.User.Username,
                    Ward = booking.User.Ward
                },
                Class = new BookingClassViewModel
                {
                    ClassLevel = booking.Schedule.Class.ClassLevel,
                    ClassInfo = booking.Schedule.Class.ClassInfo,
                    ClassId = booking.Schedule.Class.ClassId,
                    Active = booking.Schedule.Class.Active,
                    City = booking.Schedule.Class.City,
                    ClassFee = booking.Schedule.Class.ClassFee,
                    ClassMethod = booking.Schedule.Class.ClassMethod,
                    ClassName = booking.Schedule.Class.ClassName,
                    ClassRequire = booking.Schedule.Class.ClassRequire,
                    CreatedDate = booking.Schedule.Class.CreatedDate,
                    District = booking.Schedule.Class.District,
                    Ward = booking.Schedule.Class.Ward
                },
                Tutor = new BookingUserViewModel
                {
                    City = booking.Schedule.Class.Tutor.City,
                    FullName = booking.Schedule.Class.Tutor.FullName,
                    DateOfBirth = booking.Schedule.Class.Tutor.DateOfBirth,
                    District = booking.Schedule.Class.Tutor.District,
                    EmailAddress = booking.Schedule.Class.Tutor.EmailAddress,
                    Gender = booking.Schedule.Class.Tutor.Gender,
                    PhoneNumber = booking.Schedule.Class.Tutor.PhoneNumber,
                    ProfileImage = booking.Schedule.Class.Tutor.ProfileImage,
                    Street = booking.Schedule.Class.Tutor.Street,
                    UserId = booking.Schedule.Class.Tutor.UserId,
                    Username = booking.Schedule.Class.Tutor.Username,
                    Ward = booking.Schedule.Class.Tutor.Ward
                }
            }).ToList();
        }

        public async Task<List<BookingDetailViewModel>> GetBookingByTutorId(int tutorId)
        {
            var booking = await _context.Bookings
                .Include(b => b.Schedule)
                .ThenInclude(b => b.Class)
                .ThenInclude(b => b.Tutor)
                .Include(b => b.User)
                .ToListAsync();
            return booking.Select(booking => new BookingDetailViewModel
            {
                BookingId = booking.BookingId,
                CreateDate = booking.CreateDate,
                Description = booking.Description,
                Address = booking.Address,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                Status = booking.Status,
                Schedule = new BookingScheduleViewModel
                {
                    ScheduleID = booking.ScheduleId,
                    DateOfWeek = booking.Schedule.DateOfWeek,
                    Description = booking.Schedule.Description,
                    EndTime = booking.Schedule.EndTime,
                    StartTime = booking.Schedule.StartTime,
                    Title = booking.Schedule.Title,
                },
                User = new BookingUserViewModel
                {
                    City = booking.User.City,
                    DateOfBirth = booking.User.DateOfBirth,
                    District = booking.User.District,
                    EmailAddress = booking.User.EmailAddress,
                    FullName = booking.User.FullName,
                    Gender = booking.User.Gender,
                    PhoneNumber = booking.User.PhoneNumber,
                    ProfileImage = booking.User.ProfileImage,
                    Street = booking.User.Street,
                    UserId = booking.User.UserId,
                    Username = booking.User.Username,
                    Ward = booking.User.Ward
                },
                Class = new BookingClassViewModel
                {
                    ClassLevel = booking.Schedule.Class.ClassLevel,
                    ClassInfo = booking.Schedule.Class.ClassInfo,
                    ClassId = booking.Schedule.Class.ClassId,
                    Active = booking.Schedule.Class.Active,
                    City = booking.Schedule.Class.City,
                    ClassFee = booking.Schedule.Class.ClassFee,
                    ClassMethod = booking.Schedule.Class.ClassMethod,
                    ClassName = booking.Schedule.Class.ClassName,
                    ClassRequire = booking.Schedule.Class.ClassRequire,
                    CreatedDate = booking.Schedule.Class.CreatedDate,
                    District = booking.Schedule.Class.District,
                    Ward = booking.Schedule.Class.Ward
                },
                Tutor = new BookingUserViewModel
                {
                    City = booking.Schedule.Class.Tutor.City,
                    FullName = booking.Schedule.Class.Tutor.FullName,
                    DateOfBirth = booking.Schedule.Class.Tutor.DateOfBirth,
                    District = booking.Schedule.Class.Tutor.District,
                    EmailAddress = booking.Schedule.Class.Tutor.EmailAddress,
                    Gender = booking.Schedule.Class.Tutor.Gender,
                    PhoneNumber = booking.Schedule.Class.Tutor.PhoneNumber,
                    ProfileImage = booking.Schedule.Class.Tutor.ProfileImage,
                    Street = booking.Schedule.Class.Tutor.Street,
                    UserId = booking.Schedule.Class.Tutor.UserId,
                    Username = booking.Schedule.Class.Tutor.Username,
                    Ward = booking.Schedule.Class.Tutor.Ward
                }
            }).Where(b => b.Tutor.UserId == tutorId).ToList();
        }
        public async Task<List<BookingDetailViewModel>> GetBookingByStudentId(int studentId)
        {
            var booking = await _context.Bookings
                .Include(b => b.Schedule)
                .ThenInclude(b => b.Class)
                .ThenInclude(b => b.Tutor)
                .Include(b => b.User)
                .ToListAsync();
            return booking.Select(booking => new BookingDetailViewModel
            {
                BookingId = booking.BookingId,
                CreateDate = booking.CreateDate,
                Description = booking.Description,
                Address = booking.Address,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                Status = booking.Status,
                Schedule = new BookingScheduleViewModel
                {
                    ScheduleID = booking.ScheduleId,
                    DateOfWeek = booking.Schedule.DateOfWeek,
                    Description = booking.Schedule.Description,
                    EndTime = booking.Schedule.EndTime,
                    StartTime = booking.Schedule.StartTime,
                    Title = booking.Schedule.Title,
                },
                User = new BookingUserViewModel
                {
                    City = booking.User.City,
                    DateOfBirth = booking.User.DateOfBirth,
                    District = booking.User.District,
                    EmailAddress = booking.User.EmailAddress,
                    FullName = booking.User.FullName,
                    Gender = booking.User.Gender,
                    PhoneNumber = booking.User.PhoneNumber,
                    ProfileImage = booking.User.ProfileImage,
                    Street = booking.User.Street,
                    UserId = booking.User.UserId,
                    Username = booking.User.Username,
                    Ward = booking.User.Ward
                },
                Class = new BookingClassViewModel
                {
                    ClassLevel = booking.Schedule.Class.ClassLevel,
                    ClassInfo = booking.Schedule.Class.ClassInfo,
                    ClassId = booking.Schedule.Class.ClassId,
                    Active = booking.Schedule.Class.Active,
                    City = booking.Schedule.Class.City,
                    ClassFee = booking.Schedule.Class.ClassFee,
                    ClassMethod = booking.Schedule.Class.ClassMethod,
                    ClassName = booking.Schedule.Class.ClassName,
                    ClassRequire = booking.Schedule.Class.ClassRequire,
                    CreatedDate = booking.Schedule.Class.CreatedDate,
                    District = booking.Schedule.Class.District,
                    Ward = booking.Schedule.Class.Ward
                },
                Tutor = new BookingUserViewModel
                {
                    City = booking.Schedule.Class.Tutor.City,
                    FullName = booking.Schedule.Class.Tutor.FullName,
                    DateOfBirth = booking.Schedule.Class.Tutor.DateOfBirth,
                    District = booking.Schedule.Class.Tutor.District,
                    EmailAddress = booking.Schedule.Class.Tutor.EmailAddress,
                    Gender = booking.Schedule.Class.Tutor.Gender,
                    PhoneNumber = booking.Schedule.Class.Tutor.PhoneNumber,
                    ProfileImage = booking.Schedule.Class.Tutor.ProfileImage,
                    Street = booking.Schedule.Class.Tutor.Street,
                    UserId = booking.Schedule.Class.Tutor.UserId,
                    Username = booking.Schedule.Class.Tutor.Username,
                    Ward = booking.Schedule.Class.Tutor.Ward
                }
            }).Where(b => b.User.UserId == studentId).ToList();
        }
        public async Task<BookingViewModel> GetById(int bookingId)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.BookingId == bookingId);
            if (booking == null)
            {
                throw new NotFoundException("Can not find the Booking");
            }
            return new BookingViewModel
            {
                BookingId = booking.BookingId,
                CreateDate = booking.CreateDate,
                Description = booking.Description,
                Address = booking.Address,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                Status = booking.Status,
                ScheduleId = booking.ScheduleId,
                UserId = booking.UserId
            };
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
            return new BookingDetailViewModel
            {
                BookingId = booking.BookingId,
                CreateDate = booking.CreateDate,
                Description = booking.Description,
                Address = booking.Address,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                Status = booking.Status,
                Schedule = new BookingScheduleViewModel
                {
                    ScheduleID = booking.ScheduleId,
                    DateOfWeek = booking.Schedule.DateOfWeek,
                    Description = booking.Schedule.Description,
                    EndTime = booking.Schedule.EndTime,
                    StartTime = booking.Schedule.StartTime,
                    Title = booking.Schedule.Title,
                },
                User = new BookingUserViewModel
                {
                    City = booking.User.City,
                    DateOfBirth = booking.User.DateOfBirth,
                    District = booking.User.District,
                    EmailAddress = booking.User.EmailAddress,
                    FullName = booking.User.FullName,
                    Gender = booking.User.Gender,
                    PhoneNumber = booking.User.PhoneNumber,
                    ProfileImage = booking.User.ProfileImage,
                    Street = booking.User.Street,
                    UserId = booking.User.UserId,
                    Username = booking.User.Username,
                    Ward = booking.User.Ward
                },
                Class = new BookingClassViewModel
                {
                    ClassLevel = booking.Schedule.Class.ClassLevel,
                    ClassInfo = booking.Schedule.Class.ClassInfo,
                    ClassId = booking.Schedule.Class.ClassId,
                    Active = booking.Schedule.Class.Active,
                    City = booking.Schedule.Class.City,
                    ClassFee = booking.Schedule.Class.ClassFee,
                    ClassMethod = booking.Schedule.Class.ClassMethod,
                    ClassName = booking.Schedule.Class.ClassName,
                    ClassRequire = booking.Schedule.Class.ClassRequire,
                    CreatedDate = booking.Schedule.Class.CreatedDate,
                    District = booking.Schedule.Class.District,
                    Ward = booking.Schedule.Class.Ward
                },
                Tutor = new BookingUserViewModel
                {
                    City = booking.Schedule.Class.Tutor.City,
                    FullName = booking.Schedule.Class.Tutor.FullName,
                    DateOfBirth = booking.Schedule.Class.Tutor.DateOfBirth,
                    District = booking.Schedule.Class.Tutor.District,
                    EmailAddress = booking.Schedule.Class.Tutor.EmailAddress,
                    Gender = booking.Schedule.Class.Tutor.Gender,
                    PhoneNumber = booking.Schedule.Class.Tutor.PhoneNumber,
                    ProfileImage = booking.Schedule.Class.Tutor.ProfileImage,
                    Street = booking.Schedule.Class.Tutor.Street,
                    UserId = booking.Schedule.Class.Tutor.UserId,
                    Username = booking.Schedule.Class.Tutor.Username,
                    Ward = booking.Schedule.Class.Tutor.Ward
                }
            };
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
