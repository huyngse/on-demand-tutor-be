using System;
namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
	public class Schedule
    {
        public int ScheduleID { get; set; }
        public string LessonName { get; set; }
        public DateTime Date { get; set; }
        public int TutorID { get; set; }
        public int StudentID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public int SubjectID { get; set; }
        public int ClassID { get; set; }

        public virtual Tutor Tutor { get; set; }
        public virtual Parent Student { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Class Class { get; set; }
    }
}

