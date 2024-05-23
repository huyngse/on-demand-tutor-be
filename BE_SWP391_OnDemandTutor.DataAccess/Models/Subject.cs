using System;
namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
	public class Subject
	{
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}

