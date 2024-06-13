using BE_SWP391_OnDemandTutor.DataAccess.Models;
namespace BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Rate

{

   public class CreateRateRequestModel {
        public String Student { get; set; }
        public String Tutor { get; set; }
        public int NumberStars { get; set; }


    }

}
