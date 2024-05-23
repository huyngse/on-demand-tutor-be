using System;
namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
	public class Class
	{
        public int ClassID { get; set; }
        public int TutorID { get; set; }
        public int SubjectID { get; set; }
        public string ClassName { get; set; }
        public DateTime ClassTime { get; set; }
        public string ClassRoom { get; set; }
        public string ClassFloor { get; set; }
        public string ClassAddress { get; set; }
        public string ClassMethod { get; set; }
        public string ClassLevel { get; set; }

        public virtual Tutor Tutor { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}

