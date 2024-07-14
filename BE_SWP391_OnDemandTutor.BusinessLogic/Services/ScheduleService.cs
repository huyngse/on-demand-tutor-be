using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Schedule;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.Booking;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.Schedule;
using BE_SWP391_OnDemandTutor.Common.Paging;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface IScheduleService
    {
        Task<ScheduleViewModel> GetById(int scheduleId);
        Task<ScheduleDetailViewModel> GetDetailById(int scheduleId);
        Task<List<ScheduleDetailViewModel>> GetAll(PagingSizeModel paging);
        Task<List<ScheduleDetailViewModel>> GetShedulesByClassId(int classId);
        Task<ScheduleViewModel> CreateSchedule(CreateScheduleRequestModel scheduleCreate);
        Task<ScheduleViewModel> UpdateSchedule(int scheduleId, UpdateScheduleRequestModel scheduleUpdate);
        Task<bool> DeleteSchedule(int scheduleId);
    }

    public class ScheduleService : IScheduleService
    {
        private readonly BE_SWP391_OnDemandTutorDbContext _context;
        private readonly IUserService _userService;

        public ScheduleService(BE_SWP391_OnDemandTutorDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<ScheduleViewModel> CreateSchedule(CreateScheduleRequestModel scheduleCreate)
        {

            var schedule = scheduleCreate.Adapt<Schedule>();
            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();

            return schedule.Adapt<ScheduleViewModel>();
        }

        public async Task<bool> DeleteSchedule(int scheduleId)
        {
            var schedule = await _context.Schedules.FindAsync(scheduleId);
            if (schedule == null)
            {
                return false;
            }

            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<ScheduleDetailViewModel>> GetAll(PagingSizeModel paging)
        {
            var schedules = await _context.Schedules
                .Include(s => s.Bookings)
                .ThenInclude(s => s.User).ToListAsync();

            return schedules.Skip((paging.Page - 1) * paging.Limit).Take(paging.Limit).Select(schedule =>
            {
                var bookingViewModels = schedule.Bookings.Select(booking => booking.Adapt<ScheduleBookingViewModel>()).ToList();
                return schedule.Adapt<ScheduleDetailViewModel>();
            }
            ).ToList(); ;
        }

        public async Task<List<ScheduleDetailViewModel>> GetShedulesByClassId(int classId)
        {
            var schedules = await _context.Schedules
               .Include(s => s.Bookings)
               .ThenInclude(s => s.User).ToListAsync();

            return schedules.Select(schedule =>
            {
                var bookingViewModels = schedule.Bookings.Select(booking => new ScheduleBookingViewModel
                {
                    Address = booking.Address,
                    BookingId = booking.BookingId,
                    CreateDate = booking.CreateDate,
                    Description = booking.Description,
                    EndDate = booking.EndDate,
                    StartDate = booking.StartDate,
                    Status = booking.Status,
                    Student = new ScheduleUserViewModel
                    {
                        FullName = booking.User.FullName,
                        EmailAddress = booking.User.EmailAddress,
                        District = booking.User.District,
                        UserId = booking.User.UserId,
                        City = booking.User.City,
                        DateOfBirth = booking.User.DateOfBirth,
                        Gender = booking.User.Gender,
                        PhoneNumber = booking.User.PhoneNumber,
                        ProfileImage = booking.User.ProfileImage,
                        Street = booking.User.Street,
                        Username = booking.User.Username,
                        Ward = booking.User.Ward
                    }
                }).ToList();
                return new ScheduleDetailViewModel
                {
                    ScheduleID = schedule.ScheduleID,
                    Title = schedule.Title,
                    Description = schedule.Description,
                    ClassID = schedule.ClassID,
                    DateOfWeek = schedule.DateOfWeek,
                    EndTime = schedule.EndTime,
                    StartTime = schedule.StartTime,
                    Bookings = bookingViewModels
                };
            }
            ).Where(s => s.ClassID == classId).ToList(); ;
        }

        public async Task<ScheduleViewModel> GetById(int scheduleId)
        {
            var schedule = await _context.Schedules.FirstOrDefaultAsync(s => s.ScheduleID == scheduleId);
            if (schedule == null)
            {
                return null;
            }
            return schedule.Adapt<ScheduleViewModel>();
        }
        public async Task<ScheduleDetailViewModel> GetDetailById(int scheduleId)
        {
            var schedule = await _context.Schedules.Include(s => s.Bookings).ThenInclude(s => s.User).FirstOrDefaultAsync(s => s.ScheduleID == scheduleId);
            if (schedule == null)
            {
                return null;
            }
            var bookingViewModels = schedule.Bookings.Select(booking => new ScheduleBookingViewModel
            {
                Address = booking.Address,
                BookingId = booking.BookingId,
                CreateDate = booking.CreateDate,
                Description = booking.Description,
                EndDate = booking.EndDate,
                StartDate = booking.StartDate,
                Status = booking.Status,
                Student = new ScheduleUserViewModel
                {
                    FullName = booking.User.FullName,
                    EmailAddress = booking.User.EmailAddress,
                    District = booking.User.District,
                    UserId = booking.User.UserId,
                    City = booking.User.City,
                    DateOfBirth = booking.User.DateOfBirth,
                    Gender = booking.User.Gender,
                    PhoneNumber = booking.User.PhoneNumber,
                    ProfileImage = booking.User.ProfileImage,
                    Street = booking.User.Street,
                    Username = booking.User.Username,
                    Ward = booking.User.Ward
                }
            }).ToList();
            return new ScheduleDetailViewModel
            {
                ScheduleID = schedule.ScheduleID,
                Title = schedule.Title,
                Description = schedule.Description,
                ClassID = schedule.ClassID,
                DateOfWeek = schedule.DateOfWeek,
                EndTime = schedule.EndTime,
                StartTime = schedule.StartTime,
                Bookings = bookingViewModels
            };
        }


        public async Task<ScheduleViewModel> UpdateSchedule(int scheduleId, UpdateScheduleRequestModel scheduleUpdate)
        {
            var schedule = await _context.Schedules.FindAsync(scheduleId);
            if (schedule == null)
            {
                return null;
            }

            schedule.Title = scheduleUpdate.Title;
            schedule.Description = scheduleUpdate.Description;

            await _context.SaveChangesAsync();

            return schedule.Adapt<ScheduleViewModel>();
        }
    }

}
