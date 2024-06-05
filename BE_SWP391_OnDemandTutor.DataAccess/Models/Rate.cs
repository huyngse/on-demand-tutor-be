namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
    public class Rate
    {
        public int RatingId { get; set; }
        public int StudentId { get; set; }
        public User Student { get; set; }
        public int TutorId { get; set; }
        public User Tutor { get; set; }
        public int NumberStars { get; set; }
        public int SubjectId { get; set; }
        
    }
}
