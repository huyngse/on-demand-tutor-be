namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public DateTime ClassTime { get; set; }
        public string ClassInfo { get; set; }
        public string ClassRequire { get; set; }
        public string ClassAddress { get; set; }
        public string ClassMethod { get; set; }
        public string ClassLevel { get; set; }
        public float ClassFee { get; set; }
        public int StudentId { get; set; }
        public User Student { get; set; }
        public int TutorId { get; set; }
        public User Tutor { get; set; }
        public Feedback Feedback { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
