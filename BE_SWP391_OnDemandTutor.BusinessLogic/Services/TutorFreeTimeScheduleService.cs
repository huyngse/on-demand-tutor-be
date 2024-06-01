using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.TutorFreeTimeSchedule;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface ITutorFreeTimeScheduleService
    {
        public TutorFreeTimeScheduleViewModel CreateTutorFreeTimeSchedule(CreateTutorFreeTimeScheduleRequestModel tutorfreetimescheduleCreate);
        public TutorFreeTimeScheduleViewModel UpdateTutorFreeTimeSchedule(UpdateTutorFreeTimeScheduleRequestModel tutorfreetimescheduleUpdate);
        public bool DeleteTutorFreeTimeSchedule(int idTmp);
        public List<TutorFreeTimeScheduleViewModel> GetAll();
        public TutorFreeTimeScheduleViewModel GetById(int idTmp);
    }

    public class TutorFreeTimeScheduleService : ITutorFreeTimeScheduleService
    {

        public TutorFreeTimeScheduleViewModel CreateTutorFreeTimeSchedule(CreateTutorFreeTimeScheduleRequestModel tutorfreetimescheduleCreate)
        {
            throw new NotImplementedException();
        }

        public TutorFreeTimeScheduleViewModel UpdateTutorFreeTimeSchedule(UpdateTutorFreeTimeScheduleRequestModel tutorfreetimescheduleUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTutorFreeTimeSchedule(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<TutorFreeTimeScheduleViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public TutorFreeTimeScheduleViewModel GetById(int idTmp)
        {
            throw new NotImplementedException();
        }

    }

}
