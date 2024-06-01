namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
    public class TutorDegree
    {
        public int DegreeId { get; set; }
        public  string DegreeName { get; set; }
        public  string Description { get; set; }
        public string DegreeImageUrl { get; set; }
        public int TutorId { get; set; }
        public User Tutor { get; set; }
    }
}
