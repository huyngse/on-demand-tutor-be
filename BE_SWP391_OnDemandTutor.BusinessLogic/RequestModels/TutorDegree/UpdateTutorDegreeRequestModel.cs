
namespace BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.TutorDegree 
{

   public class UpdateTutorDegreeRequestModel {
        public int DegreeId { get; set; }
        public string DegreeName { get; set; }
        public string Description { get; set; }
        public string DegreeImageUrl { get; set; }
        public int TutorId { get; set; }

    }

}
