

using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Class;
using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BE_SWP391_OnDemandTutor.Presentation.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/classs")]
    public class ClassController : ControllerBase {

        private IClassService _classService;

         public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClass([FromBody] CreateClassRequestModel classCreate, [FromQuery] int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _classService.CreateClass(classCreate, userId);
            return CreatedAtAction(nameof(GetClassById), new { id = result.ClassId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> DeactivateClass(int id)
        {
            var (success, className) = await _classService.DeactivateClass(id);

            if (!success)
            {
                return NotFound();
            }

            return Ok(new { Message = $"Class {className} deactivated successfully." });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassById(int id)
        {
            var classEntity = await _classService.GetById(id);

            if (classEntity == null)
            {
                return NotFound();
            }

            return Ok(classEntity);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetClassDetail(int id)
        {
            var classEntity = await _classService.GetDetail(id);

            if (classEntity == null)
            {
                return NotFound();
            }

            return Ok(classEntity);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateClass([FromBody] UpdateClassRequestModel classUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _classService.UpdateInforClass(classUpdate);

            if (!success)
            {
                return NotFound();
            }

            return Ok(new { Message = "Class updated successfully." });
        }

    }

}
