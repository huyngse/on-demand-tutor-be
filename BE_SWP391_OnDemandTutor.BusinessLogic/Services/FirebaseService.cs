using System;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface IFirebaseService
    {
        Task<string> UploadUserImage(IFormFile image);
        Task<string> UpdloadTutorDegree(IFormFile image);

    }

    public class FirebaseService : IFirebaseService
    {
        public IConfiguration _configuration;

        public FirebaseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> UploadUserImage(IFormFile image)
        {
            string firebaseBucket = _configuration["Firebase:StorageBucket"];

            var firebaseStorage = new FirebaseStorage(firebaseBucket);

            string filename = Guid.NewGuid().ToString() + "_" + image.FileName;

            var task = firebaseStorage.Child("User").Child(filename);

            var stream = image.OpenReadStream();
            await task.PutAsync(stream);

            return await task.GetDownloadUrlAsync();
        }
        public async Task<string> UpdloadTutorDegree(IFormFile image)
        {
            string firebaseBucket = _configuration["Firebase:StorageBucket"];

            var firebaseStorage = new FirebaseStorage(firebaseBucket);

            string filename = Guid.NewGuid().ToString() + "_" + image.FileName;

            var task = firebaseStorage.Child("TutouDegree").Child(filename);

            var stream = image.OpenReadStream();
            await task.PutAsync(stream);

            return await task.GetDownloadUrlAsync();
        }

    }
}

