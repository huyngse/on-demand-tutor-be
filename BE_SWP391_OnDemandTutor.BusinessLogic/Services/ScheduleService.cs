using BE_SWP391_OnDemandTutor.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Schedule;
using Ecommerce.BusinessLogic.ViewModels;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface IScheduleService
    {
        public ScheduleViewModel CreateSchedule(CreateScheduleRequestModel scheduleCreate);
        public ScheduleViewModel UpdateSchedule(UpdateScheduleRequestModel scheduleUpdate);
        public bool DeleteSchedule(int idTmp);
        public List<ScheduleViewModel> GetAll();
        public ScheduleViewModel GetById(int idTmp);
    }

    public class ScheduleService : IScheduleService
    {

        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public ScheduleViewModel CreateSchedule(CreateScheduleRequestModel scheduleCreate)
        {
            throw new NotImplementedException();
        }

        public ScheduleViewModel UpdateSchedule(UpdateScheduleRequestModel scheduleUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSchedule(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<ScheduleViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ScheduleViewModel GetById(int idTmp)
        {
            throw new NotImplementedException();
        }

    }

}
