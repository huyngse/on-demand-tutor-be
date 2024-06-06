using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Schedule;
using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BE_SWP391_OnDemandTutor.Presentation.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/schedules")]
    public class ScheduleController : ControllerBase {

        private IScheduleService _scheduleService;

         public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<ScheduleViewModel> CreateSchedule(CreateScheduleRequestModel scheduleCreate)
        {
            var scheduleCreated = _scheduleService.CreateSchedule(scheduleCreate);

            if (scheduleCreated == null)
            {
                return NotFound("");
            }
            return scheduleCreated;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<ScheduleViewModel>> GetAll()
        {
            var scheduleList = _scheduleService.GetAll();

            if (scheduleList == null)
            {
                return NotFound("");
            }
            return scheduleList;
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public ActionResult<ScheduleViewModel> GetById(int idTmp)
        {
            var scheduleDetail = _scheduleService.GetById(idTmp);

            if (scheduleDetail == null)
            {
                return NotFound("");
            }
            return scheduleDetail;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<bool> DeleteSchedule(int idTmp)
        {
            var check = _scheduleService.DeleteSchedule(idTmp);

            if (check == false)
            {
                return NotFound("");
            }
            return check;
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public ActionResult<ScheduleViewModel> UpdateSchedule(UpdateScheduleRequestModel scheduleCreate)
        {
            var scheduleUpdated = _scheduleService.UpdateSchedule(scheduleCreate);

            if (scheduleUpdated == null)
            {
                return NotFound("");
            }
            return scheduleUpdated;
        }
    }

}
