using System;
namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
	public class Feedback
	{
        public Guid FeedbackID { get; set; }
        public string Evaluation { get; set; }
        public Guid StudentID { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid TutorID { get; set; }

        public Parent Parent { get; set; }
        public Tutor Tutor { get; set; }
    }
}

