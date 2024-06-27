using System;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Class;
using System.Data;
using BE_SWP391_OnDemandTutor.BusinessLogic.Services;

using Microsoft.AspNetCore.Mvc;
using Firebase.Storage;
using BE_SWP391_OnDemandTutor.DataAccess.Models;

namespace BE_SWP391_OnDemandTutor.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/Firebase")]
    public class FirebaseController : ControllerBase
    {
        public IConfiguration _configuration;
        private IFirebaseService _firebaseService;
        public FirebaseController(IFirebaseService firebaseService)
		{
            _firebaseService = firebaseService;
		}

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile? image)
        {
           var rs = await _firebaseService.UploadUserImage(image);
            return Ok(rs);
        }

    }
}

