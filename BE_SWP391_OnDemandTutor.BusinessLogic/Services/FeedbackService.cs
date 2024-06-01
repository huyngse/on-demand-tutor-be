using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Feedback;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface IFeedbackService
    {
        public FeedbackViewModel CreateFeedback(CreateFeedbackRequestModel feedbackCreate);
        public FeedbackViewModel UpdateFeedback(UpdateFeedbackRequestModel feedbackUpdate);
        public bool DeleteFeedback(int idTmp);
        public List<FeedbackViewModel> GetAll();
        public FeedbackViewModel GetById(int idTmp);
    }

    public class FeedbackService : IFeedbackService
    {

     
        public FeedbackViewModel CreateFeedback(CreateFeedbackRequestModel feedbackCreate)
        {
            throw new NotImplementedException();
        }

        public FeedbackViewModel UpdateFeedback(UpdateFeedbackRequestModel feedbackUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFeedback(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<FeedbackViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public FeedbackViewModel GetById(int idTmp)
        {
            throw new NotImplementedException();
        }

    }

}
