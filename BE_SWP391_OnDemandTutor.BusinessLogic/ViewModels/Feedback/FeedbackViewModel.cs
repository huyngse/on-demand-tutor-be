
using BE_SWP391_OnDemandTutor.DataAccess.Models;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels 
{

    public class FeedbackViewModel {
        public int FeedbackID { get; set; }
        public int Evaluation { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }

    }

}
