using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.User;
using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BE_SWP391_OnDemandTutor.Presentation.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/users")]
    public class UserController : ControllerBase
    {

        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<string>> Login(LoginRequestModel request)
        {
            var result = await _userService.Login(request);

            return result;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<UserViewModel>> CreateUser(RegisterRequestModel userCreate)
        {
            var userCreated = await _userService.Register(userCreate);

            if (userCreated == null)
            {
                return NotFound("");
            }
            return userCreated;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public async Task<ActionResult<List<UserViewModel>>> GetAll()
        {
            var userList = await _userService.GetAll();

            if (userList == null)
            {
                return NotFound("");
            }
            return userList;
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public async Task<ActionResult<UserViewModel>> GetById(int idTmp)
        {
            var userDetail = await _userService.GetById(idTmp);

            if (userDetail == null)
            {
                return NotFound("");
            }
            return userDetail;
        }


        [MapToApiVersion("1")]
        [HttpPut]
        public async Task<ActionResult<UserViewModel>> UpdateUser(UpdateUserRequestModel userCreate)
        {
            var userUpdated = await _userService.UpdateUser(userCreate);

            if (userUpdated == null)
            {
                return NotFound("");
            }
            return userUpdated;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public async Task<ActionResult<UserViewModel>> DeleteUser(DeleteUserModel userDelete, int idTmp)
        {
            var userRemove = await _userService.DeleteUser(userDelete);
            var userDetail = await _userService.GetById(idTmp);

            if (userDetail == null)
            {
                return NotFound("");
            }
            return Ok(userRemove);
        }
    }

}
