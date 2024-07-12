using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Schedule;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.TutorDegree;
using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.Common.Paging;
using Microsoft.AspNetCore.Mvc;

namespace BE_SWP391_OnDemandTutor.Presentation.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/tutordegrees")]
    public class TutorDegreeController : ControllerBase {

        private ITutorDegreeService _tutordegreeService;

         public TutorDegreeController(ITutorDegreeService tutordegreeService)
        {
            _tutordegreeService = tutordegreeService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateTutorDegreeRequestModel degreeCreate)
        {
            try
            {
                var createdDegree = await _tutordegreeService.CreateTutorDegree(degreeCreate);
                return CreatedAtAction(nameof(GetById), new { id = createdDegree.DegreeId }, createdDegree);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public async Task<ActionResult<List<TutorDegreeViewModel>>> GetAll([FromQuery] PagingSizeModel paging)
        {
            var degree = await _tutordegreeService.GetAll(paging);
            if (degree == null)
            {
                return NotFound("");
            }
            return Ok(degree);
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public async Task<IActionResult> GetById(int id)
        {
            var degree = await _tutordegreeService.GetById(id);
            if (degree == null)
            {
                return NotFound();
            }

            return Ok(degree);
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _tutordegreeService.DeleteTutorDegree(id);
            if (!success)
            {
                return NotFound();
            }

            return Ok(new { Message = $"Tutor Degree with ID '{id}' deleted successfully." });
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateTutorDegreeRequestModel degreeUpdate)
        {
            if (id != degreeUpdate.DegreeId)
            {
                return BadRequest("ID in the request body does not match the route parameter.");
            }

            var updatedDegree = await _tutordegreeService.UpdateDegree(degreeUpdate);
            if (updatedDegree == null)
            {
                return NotFound();
            }

            return Ok(updatedDegree);
        }
    }

}
