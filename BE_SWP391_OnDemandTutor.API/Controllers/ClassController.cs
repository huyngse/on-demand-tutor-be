

using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Class;
using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Administrator, Tutor")] 
        public async Task<IActionResult> CreateClass([FromBody] CreateClassRequestModel classCreate)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _classService.CreateClass(classCreate);
            return result is not null ? CreatedAtAction(nameof(GetClassById), new { id = result.ClassId }, result): BadRequest("Failed to create Class.");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator, Tutor")]
        public async Task<IActionResult> DeactivateClass(int id)
        {
            var (success, className) = await _classService.DeactivateClass(id);

            if (!success)
            {
                return NotFound(new { Message = "Invalid class ID, student ID, or tutor ID." });
            }

            return Ok(new { Message = $"Class {className} change the status successfully." });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassById(int id)
        {
            var classEntity = await _classService.GetById(id);

            if (classEntity == null)
            {
                return NotFound(new { Message = "Invalid class ID, student ID, or tutor ID." });
            }

            return Ok(classEntity);
        }

        [HttpGet("Detail/{classId}")]
        public async Task<IActionResult> GetClassDetail(int classId)
        {
            var classEntity = await _classService.GetDetail(classId);

            if (classEntity == null)
            {
                return NotFound(new { Message = "Invalid class ID, student ID, or tutor ID." });
            }

            return Ok(classEntity);
        }

        [HttpPut("class/{classId}")]
        //[Authorize(Roles = "Administrator, Tutor")]
        public async Task<IActionResult> UpdateClass([FromBody] UpdateClassRequestModel classUpdate, int classId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _classService.UpdateInforClass(classUpdate, classId);

            if (!success)
            {
                return NotFound(new { Message = "Invalid class ID, student ID, or tutor ID." });
            }

            return Ok(new { Message = "Class updated successfully." });
        }


        [HttpGet("classes")]
        public async Task<IActionResult> GetAllClasses()
        {
            var classViewModels = await _classService.GetAllClasses();
            return Ok(classViewModels);
        }

    }

}
