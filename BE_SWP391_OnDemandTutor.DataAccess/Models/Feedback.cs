namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
    public class Feedback
	{
        public int FeedbackID { get; set; }
        public int Evaluation { get; set; }
        public DateTime CreateDate { get; set; }
        public int StudentId { get; set; }
        public User Student { get; set; }
        public int TutorId { get; set; }
        public User Tutor { get; set; }
        public int SlotId { get; set; }
        public Slot Slot { get; set; }
    }
}

