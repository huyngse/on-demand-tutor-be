using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Schedule;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.Booking;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface IScheduleService
    {
        Task<ScheduleViewModel> GetById(int idTmp);
        Task<List<ScheduleViewModel>> GetAll();
        Task<ScheduleViewModel> CreateSchedule(CreateScheduleRequestModel scheduleCreate);
        Task<ScheduleViewModel> UpdateSchedule(int id,UpdateScheduleRequestModel scheduleUpdate);
        Task<bool> DeleteSchedule(int idTmp);
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

        public async Task<bool> DeleteSchedule(int idTmp)
        {
            var schedule = await _context.Schedules.FindAsync(idTmp);
            if (schedule == null)
            {
                return false;
            }

            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<ScheduleViewModel>> GetAll()
        {
            var schedules = await _context.Schedules.ToListAsync();
      
            return schedules.Adapt<List<ScheduleViewModel>>();
        }

        public async Task<ScheduleViewModel> GetById(int idTmp)
        {
            var schedule = await _context.Schedules.FindAsync(idTmp);
            if (schedule == null)
            {
                return null;
            }
             
            return schedule.Adapt<ScheduleViewModel>();
        }

        public async Task<ScheduleViewModel> UpdateSchedule(int id, UpdateScheduleRequestModel scheduleUpdate)
        {
            var schedule = await _context.Schedules.FindAsync(id);
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
