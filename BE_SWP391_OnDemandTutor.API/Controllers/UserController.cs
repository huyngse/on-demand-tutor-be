using System.Security.Claims;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Class;
using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security;

namespace BE_SWP391_OnDemandTutor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [MapToApiVersion("1")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var classViewModel = await _classService.GetById(id);
            if (classViewModel == null)
            {
                return NotFound();
            }

            return Ok(classViewModel);
        }

        [MapToApiVersion("1")]
        [HttpPost("CreateClass")]
        public async Task<IActionResult> Create(CreateClassRequestModel classCreate)
        {
            try
            {

                Random random = new Random();
                int userId = random.Next();

                var createdClass = await _classService.CreateClass(classCreate, userId);
                return CreatedAtAction(nameof(GetById), new { id = createdClass.ClassId }, createdClass);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [MapToApiVersion("1")]
        [HttpPut]
        [Route("UpdateInforClass/classId")]
        [Authorize]
        public async Task<IActionResult> Update(int id, UpdateClassRequestModel classUpdate)
        {
            if (id != classUpdate.ClassId)
            {
                return BadRequest("ID in the request body does not match the route parameter.");
            }

            var success = await _classService.UpdateInforClass(classUpdate);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [MapToApiVersion("1")]
        [HttpPut]
        [Route("deactivateClass/{classId}")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var (success, className) = await _classService.DeactivateClass(id);
            if (!success)
            {
                return NotFound();
            }

            return Ok(new { Message = $"Class '{className}' deactivated successfully." });
        }
    }
}