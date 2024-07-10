using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Feedback;
using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.Common.Paging;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Tutor")]
        public async Task<ActionResult<FeedbackViewModel>> CreateFeedbacksAsync(CreateFeedbackRequestModel feedbackCreate)
        {
            try
            {
                var createFeedback = await _feedbackService.CreateFeedbacksAsync(feedbackCreate);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = createFeedback.FeedbackID }, createFeedback);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [MapToApiVersion("1")]
        [HttpPost]
        [Route("all")]
        public async Task<ActionResult<List<FeedbackViewModel>>> GetAll(PagingSizeModel paging)
        {
            var feedback = await _feedbackService.GetAll(paging);
            if (feedback == null)
            {
                return NotFound("");
            }
            return Ok(feedback);
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public async Task<ActionResult<FeedbackViewModel>> GetByIdAsync(int idTmp)
        {
            var feedback = await _feedbackService.GetById(idTmp);
            if (feedback == null)
            {
                return NotFound();
            }

            return Ok(feedback);
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteFeedbackAsync(int idTmp)
        {
            var delete = await _feedbackService.DeleteFeedback(idTmp);
            if (!delete)
            {
                return NotFound();
            }

            return Ok(new { Message = $"Feedback with ID '{idTmp}' deleted successfully." });
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public async Task<ActionResult<FeedbackViewModel>> UpdateFeedbackAsync(int id, UpdateFeedbackRequestModel feedbackUpdate)
        {
            if (id != feedbackUpdate.FeedbackId)
            {
                return BadRequest("ID in the request body does not match the route parameter.");
            }

            var updateFeedback = await _feedbackService.UpdateFeedbacks(feedbackUpdate);
            if (updateFeedback == null)
            {
                return NotFound();
            }

            return Ok(updateFeedback);
        }
    }

}
