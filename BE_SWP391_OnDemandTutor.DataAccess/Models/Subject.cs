using System;
namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
	public class Subject
	{
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Guid TutorID { get; set; }
        public Guid ScheduleId { get; set; }

        public Tutor Tutor { get; set; }
        public Schedule Schedule { get; set; }
        public ICollection<Class> Classes { get; set; }
    }
}

