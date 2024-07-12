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

        public ScheduleService(BE_SWP391_OnDemandTutorDbContext context)
        {
            _context = context;
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
            var bookingViewModels = schedule.Bookings.Select(booking => booking.Adapt<ScheduleBookingViewModel>() ).ToList();
                return schedule.Adapt<ScheduleDetailViewModel>() ;
            }
            ).ToList(); ;
        }

        public async Task<List<ScheduleDetailViewModel>> GetShedulesByClassId(int classId)
        {
            var schedules = await _context.Schedules
                .Include(s => s.Bookings)
                .ThenInclude(s => s.User).ToListAsync();

            var result = schedules.Select(schedule =>
            {var bookingViewModels = schedule.Bookings.Select(booking => booking.Adapt<ScheduleBookingViewModel>()
                ).ToList();
                return schedule.Adapt<ScheduleDetailViewModel>();
            }).Where(s => s.ClassID == classId).ToList();
            return result;
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
            var bookingViewModels = schedule.Bookings.Select(booking => booking.Adapt<ScheduleBookingViewModel>()).ToList();
            return schedule.Adapt<ScheduleDetailViewModel>();
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
