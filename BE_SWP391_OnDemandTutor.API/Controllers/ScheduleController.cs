using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Schedule;
using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using BE_SWP391_OnDemandTutor.Common.Paging;
using Microsoft.AspNetCore.Mvc;

namespace BE_SWP391_OnDemandTutor.Presentation.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/schedules")]
    public class ScheduleController : ControllerBase
    {

        private IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateScheduleRequestModel scheduleCreate)
        {
            try
            {
                var createdSchedule = await _scheduleService.CreateSchedule(scheduleCreate);
                return CreatedAtAction(nameof(GetById), new { scheduleId = createdSchedule.ScheduleID }, createdSchedule);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [MapToApiVersion("1")]
        [HttpPost]
        [Route("all")]
        public async Task<IActionResult> GetAll([FromQuery] PagingSizeModel paging)
        {
            var schedules = await _scheduleService.GetAll(paging);
            if (schedules == null)
            {
                return NotFound("");
            }
            return Ok(schedules);
        }

        [MapToApiVersion("1")]
        [HttpGet("class/{classId:int}")]
        public async Task<IActionResult> GetSchedulesByClassId(int classId)
        {
            var schedules = await _scheduleService.GetShedulesByClassId(classId);
            if (schedules == null)
            {
                return NotFound("");
            }
            return Ok(schedules);
        }

        [MapToApiVersion("1")]
        [HttpGet("{scheduleId:int}")]
        public async Task<IActionResult> GetById(int scheduleId)
        {
            var schedule = await _scheduleService.GetById(scheduleId);
            if (schedule == null)
            {
                return NotFound();
            }

            return Ok(schedule);
        }
        [MapToApiVersion("1")]
        [HttpGet("detail/{scheduleId:int}")]
        public async Task<IActionResult> GetDetailById(int scheduleId)
        {
            var schedule = await _scheduleService.GetDetailById(scheduleId);
            if (schedule == null)
            {
                return NotFound();
            }

            return Ok(schedule);
        }

        [MapToApiVersion("1")]
        [HttpDelete("{scheduleId:int}")]
        public async Task<IActionResult> Delete(int scheduleId)
        {
            var success = await _scheduleService.DeleteSchedule(scheduleId);
            if (!success)
            {
                return NotFound();
            }

            return Ok(new { Message = $"Schedule with ID '{scheduleId}' deleted successfully." });
        }

        [MapToApiVersion("1")]
        [HttpPut("{scheduleId:int}")]
        public async Task<IActionResult> Update(int scheduleId, [FromBody] UpdateScheduleRequestModel scheduleUpdate)
        {
            var checkid = await _scheduleService.GetById(scheduleId);
            if (scheduleId != checkid.ScheduleID)
            {
                return BadRequest("ID in the request body does not match the route parameter.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedSchedule = await _scheduleService.UpdateSchedule(scheduleId, scheduleUpdate);
            if (updatedSchedule == null)
            {
                return NotFound();
            }

            return Ok(updatedSchedule);
        }
    }

}
