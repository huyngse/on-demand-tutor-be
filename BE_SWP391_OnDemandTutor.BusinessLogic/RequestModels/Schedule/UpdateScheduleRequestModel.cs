
namespace BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Schedule 
{

   public class UpdateScheduleRequestModel {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

}
