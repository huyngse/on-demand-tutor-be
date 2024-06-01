namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
    public class Slot
    {
        public int Id { get; set; }
        public int Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public Feedback Feedback { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}
