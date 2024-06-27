using System;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Class;
using System.Data;
using BE_SWP391_OnDemandTutor.BusinessLogic.Services;

using Microsoft.AspNetCore.Mvc;
using Firebase.Storage;

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
            string firebaseBucket = "ondemandtutor-74ed2.appspot.com";

            var firebaseStorage = new FirebaseStorage(firebaseBucket);

            string filename = Guid.NewGuid().ToString() + "_" + image.FileName;

            var task = firebaseStorage.Child("User").Child(filename);

            var stream = image.OpenReadStream();
            await task.PutAsync(stream);

            var url = await task.GetDownloadUrlAsync();
            return Ok(url);
        }

    }
}

