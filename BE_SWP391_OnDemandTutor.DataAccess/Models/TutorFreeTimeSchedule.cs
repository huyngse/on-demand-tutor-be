namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
    public class TutorFreeTimeSchedule
    {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTimeTime { get; set; }
        public string DateOfWeek { get; set; }
        public bool Status { get; set; }
        public int TutorId { get; set; }
        public User Tutor { get; set; }
    }
}
