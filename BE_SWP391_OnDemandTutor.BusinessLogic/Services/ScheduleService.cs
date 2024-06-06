using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Schedule;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;

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
