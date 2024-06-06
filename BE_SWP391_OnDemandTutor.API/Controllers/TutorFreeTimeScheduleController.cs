using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.TutorFreeTimeSchedule;
using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BE_SWP391_OnDemandTutor.Presentation.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/tutorfreetimeschedules")]
    public class TutorFreeTimeScheduleController : ControllerBase
    {

        private ITutorFreeTimeScheduleService _tutorfreetimescheduleService;

        public TutorFreeTimeScheduleController(ITutorFreeTimeScheduleService tutorfreetimescheduleService)
        {
            _tutorfreetimescheduleService = tutorfreetimescheduleService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<TutorFreeTimeScheduleViewModel> CreateTutorFreeTimeSchedule(CreateTutorFreeTimeScheduleRequestModel tutorfreetimescheduleCreate)
        {
            var tutorfreetimescheduleCreated = _tutorfreetimescheduleService.CreateTutorFreeTimeSchedule(tutorfreetimescheduleCreate);

            if (tutorfreetimescheduleCreated == null)
            {
                return NotFound("");
            }
            return tutorfreetimescheduleCreated;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<TutorFreeTimeScheduleViewModel>> GetAll()
        {
            var tutorfreetimescheduleList = _tutorfreetimescheduleService.GetAll();

            if (tutorfreetimescheduleList == null)
            {
                return NotFound("");
            }
            return tutorfreetimescheduleList;
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public ActionResult<TutorFreeTimeScheduleViewModel> GetById(int idTmp)
        {
            var tutorfreetimescheduleDetail = _tutorfreetimescheduleService.GetById(idTmp);

            if (tutorfreetimescheduleDetail == null)
            {
                return NotFound("");
            }
            return tutorfreetimescheduleDetail;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<bool> DeleteTutorFreeTimeSchedule(int idTmp)
        {
            var check = _tutorfreetimescheduleService.DeleteTutorFreeTimeSchedule(idTmp);

            if (check == false)
            {
                return NotFound("");
            }
            return check;
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public ActionResult<TutorFreeTimeScheduleViewModel> UpdateTutorFreeTimeSchedule(UpdateTutorFreeTimeScheduleRequestModel tutorfreetimescheduleCreate)
        {
            var tutorfreetimescheduleUpdated = _tutorfreetimescheduleService.UpdateTutorFreeTimeSchedule(tutorfreetimescheduleCreate);

            if (tutorfreetimescheduleUpdated == null)
            {
                return NotFound("");
            }
            return tutorfreetimescheduleUpdated;
        }
    }

}
