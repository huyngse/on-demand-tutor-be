using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Schedule;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface IScheduleService
    {
        Task<ScheduleViewModel> GetById(int idTmp);
        Task<List<ScheduleViewModel>> GetAll();
        Task<ScheduleViewModel> CreateSchedule(CreateScheduleRequestModel scheduleCreate);
        Task<ScheduleViewModel> UpdateSchedule(UpdateScheduleRequestModel scheduleUpdate);
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
            var schedule = new Schedule
            {
                Title = scheduleCreate.Title,
                Description = scheduleCreate.Description,
                StartDate = scheduleCreate.StartDate,
                EndDate = scheduleCreate.EndDate
            };

            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();

            return new ScheduleViewModel
            {
                ScheduleID = schedule.ScheduleID,
                Title = schedule.Title,
                Description = schedule.Description,
                StartDate = schedule.StartDate,
                EndDate = schedule.EndDate
            };

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
            return schedules.Select(schedule => new ScheduleViewModel
            {
                ScheduleID = schedule.ScheduleID,
                Title = schedule.Title,
                Description = schedule.Description,
                StartDate = schedule.StartDate,
                EndDate = schedule.EndDate
            }).ToList();
        }

        public async Task<ScheduleViewModel> GetById(int idTmp)
        {
            var schedule = await _context.Schedules.FindAsync(idTmp);
            if (schedule == null)
            {
                return null;
            }

            return new ScheduleViewModel
            {
                ScheduleID = schedule.ScheduleID,
                Title = schedule.Title,
                Description = schedule.Description,
                StartDate = schedule.StartDate,
                EndDate = schedule.EndDate
            };
        }

        public async Task<ScheduleViewModel> UpdateSchedule(UpdateScheduleRequestModel scheduleUpdate)
        {
            var schedule = await _context.Schedules.FindAsync(scheduleUpdate.ScheduleID);
            if (schedule == null)
            {
                return null;
            }

            schedule.Title = scheduleUpdate.Title;
            schedule.Description = scheduleUpdate.Description;
            schedule.StartDate = scheduleUpdate.StartDate;
            schedule.EndDate = scheduleUpdate.EndDate;

            await _context.SaveChangesAsync();

            return new ScheduleViewModel
            {
                ScheduleID = schedule.ScheduleID,
                Title = schedule.Title,
                Description = schedule.Description,
                StartDate = schedule.StartDate,
                EndDate = schedule.EndDate
            };
        }
    }

}
