using BE_SWP391_OnDemandTutor.DataAccess.Models;
namespace BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Rate

{

    public class CreateRateRequestModel
    {
        public int StudentId { get; set; }
        public int TutorId { get; set; }
        public int NumberStars { get; set; }


    }

}