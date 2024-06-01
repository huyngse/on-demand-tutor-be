using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Feedback;
using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BE_SWP391_OnDemandTutor.Presentation.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/feedbacks")]
    public class FeedbackController : ControllerBase {

        private IFeedbackService _feedbackService;

         public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<FeedbackViewModel> CreateFeedback(CreateFeedbackRequestModel feedbackCreate)
        {
            var feedbackCreated = _feedbackService.CreateFeedback(feedbackCreate);

            if (feedbackCreated == null)
            {
                return NotFound("");
            }
            return feedbackCreated;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<FeedbackViewModel>> GetAll()
        {
            var feedbackList = _feedbackService.GetAll();

            if (feedbackList == null)
            {
                return NotFound("");
            }
            return feedbackList;
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public ActionResult<FeedbackViewModel> GetById(int idTmp)
        {
            var feedbackDetail = _feedbackService.GetById(idTmp);

            if (feedbackDetail == null)
            {
                return NotFound("");
            }
            return feedbackDetail;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<bool> DeleteFeedback(int idTmp)
        {
            var check = _feedbackService.DeleteFeedback(idTmp);

            if (check == false)
            {
                return NotFound("");
            }
            return check;
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public ActionResult<FeedbackViewModel> UpdateFeedback(UpdateFeedbackRequestModel feedbackCreate)
        {
            var feedbackUpdated = _feedbackService.UpdateFeedback(feedbackCreate);

            if (feedbackUpdated == null)
            {
                return NotFound("");
            }
            return feedbackUpdated;
        }
    }

}
