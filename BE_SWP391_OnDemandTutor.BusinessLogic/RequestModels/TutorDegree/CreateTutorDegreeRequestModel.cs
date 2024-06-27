
using Microsoft.AspNetCore.Http;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.TutorDegree
{

    public class CreateTutorDegreeRequestModel
    {
        public string DegreeName { get; set; }
        public string Description { get; set; }
        public IFormFile DegreeImageUrl { get; set; }
        public int TutorId { get; set; }

    }

}
