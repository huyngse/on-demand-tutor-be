using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Schedule;
using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
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
        public async Task<IActionResult> Create(CreateScheduleRequestModel scheduleCreate)
        {
            try
            {
                var createdSchedule = await _scheduleService.CreateSchedule(scheduleCreate);
                return CreatedAtAction(nameof(GetById), new { id = createdSchedule.ScheduleID }, createdSchedule);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var schedules = await _scheduleService.GetAll();
            if (schedules == null)
            {
                return NotFound("");
            }
            return Ok(schedules);
        }
     
        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public async Task<IActionResult> GetById(int id)
        {
            var schedule = await _scheduleService.GetById(id);
            if (schedule == null)
            {
                return NotFound();
            }

            return Ok(schedule);
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _scheduleService.DeleteSchedule(id);
            if (!success)
            {
                return NotFound();
            }

            return Ok(new { Message = $"Schedule with ID '{id}' deleted successfully." });
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateScheduleRequestModel scheduleUpdate)
        {
            var checkid =  await _scheduleService.GetById(id);
            if (id != checkid.ScheduleID)
            {
                return BadRequest("ID in the request body does not match the route parameter.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedSchedule = await _scheduleService.UpdateSchedule(id,scheduleUpdate);
            if (updatedSchedule == null)
            {
                return NotFound();
            }

            return Ok(updatedSchedule);
        }
    }

}
