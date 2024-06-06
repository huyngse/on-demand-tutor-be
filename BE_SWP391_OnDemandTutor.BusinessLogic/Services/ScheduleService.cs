using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Schedule;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;

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
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteSchedule(int idTmp)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ScheduleViewModel>> GetAll()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }

}
