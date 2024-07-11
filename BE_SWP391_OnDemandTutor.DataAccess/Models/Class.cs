namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; } = String.Empty;
        public string ClassInfo { get; set; } = String.Empty;
        public string ClassRequire { get; set; } = String.Empty;
        public string ClassAddress { get; set; } = String.Empty;
        public string ClassMethod { get; set; } = String.Empty;
        public string ClassLevel { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; }
        public string City { get; set; } = String.Empty;
        public string District { get; set; } = String.Empty;
        public string Ward { get; set; } = String.Empty;
        public string  MeetingLink { get; set; }
        public bool Active { get; set; }
        public float ClassFee { get; set; }
        public int? StudentId { get; set; }
        public User? Student { get; set; } 
        public int TutorId { get; set; }
        public User Tutor { get; set; } 
        public Feedback Feedback { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
