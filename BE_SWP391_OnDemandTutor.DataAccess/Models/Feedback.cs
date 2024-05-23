using System;
namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
	public class Feedback
	{
        public int FeedbackID { get; set; }
        public string Evaluation { get; set; }
        public int StudentID { get; set; }
        public DateTime CreateDate { get; set; }
        public int TutorID { get; set; }

        public virtual Parent Student { get; set; }
        public virtual Tutor Tutor { get; set; }
    }
}

