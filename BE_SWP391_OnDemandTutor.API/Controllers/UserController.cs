using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.User;
using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.User;
using BE_SWP391_OnDemandTutor.Common.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnDemandTutor.DataAccess.ExceptionModels;
using System.IdentityModel.Tokens.Jwt;

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
        public async Task<ActionResult<List<UserViewModel>>> GetAll([FromQuery] PagingSizeModel paging)
        {
            var userList = await _userService.GetAll(paging);

            if (userList == null)
            {
                return NotFound("");
            }
            return userList;
        }


        [MapToApiVersion("1")]
        [HttpGet]
        [Route("tutor")]
        public async Task<ActionResult<List<TutorViewModel>>> GetAllTutor([FromQuery] PagingSizeModel paging)
        {
            var userList = await _userService.GetAllTutors(paging);

            if (userList == null)
            {
                return NotFound("");
            }
            return userList;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        [Route("tutor/search")]
        public async Task<ActionResult<List<TutorViewModel>>> SearchTutor([FromQuery] SearchTutorQuery query)
        {
            var (userList, totalCount) = await _userService.SearchTutors(query);
            var totalPages = (int)Math.Ceiling((double)totalCount / query.PageSize);
            Response.Headers.Append("X-Total-Count", totalCount.ToString());
            Response.Headers.Append("X-Current-Page", query.PageNumber.ToString());
            Response.Headers.Append("X-Total-Pages", totalPages.ToString());
            if (userList == null)
            {
                return NotFound("");
            }
            return userList;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        [Route("tutor/{userId:int}")]
        public async Task<ActionResult<TutorViewModel>> GetTutorById(int userId)
        {
            var user = await _userService.GetTutorById(userId);

            if (user == null)
            {
                return NotFound("Tutor not found");
            }
            return user;
        }

        [MapToApiVersion("1")]
        [HttpGet("{userId:int}")]
        public async Task<ActionResult<UserViewModel>> GetById(int userId)
        {
            var userDetail = await _userService.GetById(userId);

            if (userDetail == null)
            {
                return NotFound("");
            }
            return userDetail;
        }


        [MapToApiVersion("1")]
        [HttpPut("{userId:int}")]
        public async Task<ActionResult<UserViewModel>> UpdateUser(int userId, [FromBody] UpdateUserRequestModel userCreate)
        {
            var userUpdated = await _userService.UpdateUser(userId, userCreate);

            if (userUpdated == null)
            {
                return NotFound("");
            }
            return userUpdated;
        }

        [MapToApiVersion("1")]
        [HttpPut("status/{userId}")]
        public async Task<ActionResult<UserViewModel>> UpdateUserStatus(int userId)
        {
            var userUpdated = await _userService.UpdateUserStatus(userId);

            if (userUpdated == null)
            {
                return NotFound("");
            }
            return userUpdated;
        }

        [MapToApiVersion("1")]
        [HttpPut("tutor/{userId}")]
        public async Task<ActionResult<UserViewModel>> UpdateTutorProfile(int userId, [FromBody] UpdateTutorProfileRequestModel request)
        {
            var userUpdated = await _userService.UpdateTutorProfile(userId, request);

            if (userUpdated == null)
            {
                return NotFound("");
            }
            return userUpdated;
        }

        [MapToApiVersion("1")]
        [HttpPut("role/{userId}")]
        public async Task<ActionResult<UserViewModel>> ChangeUserRole(int userId, [FromBody] string role)
        {
            var userUpdated = await _userService.UpdateUserRole(userId, role);

            if (userUpdated == null)
            {
                return NotFound("");
            }
            return userUpdated;
        }

        [MapToApiVersion("1")]
        [HttpPut("profileImage/{userId:int}")]
        public async Task<ActionResult<UserViewModel>> UpdateUserProfileImage(int userId, [FromBody] string imageUrl)
        {
            var userUpdated = await _userService.UpdateUserProfileImage(userId, imageUrl);

            if (userUpdated == null)
            {
                return NotFound("");
            }
            return userUpdated;
        }

        [Authorize]
        [HttpGet("/checkToken")]
        public async Task<IActionResult> CheckToken()
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            token = token.ToString().Split()[1];
            // Here goes your token validation logic
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new BadRequestException("Authorization header is missing or invalid.");
            }
            // Decode the JWT token
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            // Check if the token is expired
            if (jwtToken.ValidTo < DateTime.UtcNow)
            {
                throw new BadRequestException("Token has expired.");
            }

            string email = jwtToken.Claims.FirstOrDefault(c => c.Type == "email")?.Value;

            var user = await _userService.GetUserByEmail(email);
            if (user == null)
            {
                return BadRequest("email is in valid");
            }

            // If token is valid, return success response
            return Ok(user);
        }
    }
}
