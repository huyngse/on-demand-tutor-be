
namespace BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Feedback 
{

   public class UpdateFeedbackRequestModel {
        public int FeedbackId { get; set; }
        public int Evaluation { get; set; }
        public string Content { get; set; }
        public int StudentId { get; set; }
        public DateTime CreateDate { get; set; }


    }

}
