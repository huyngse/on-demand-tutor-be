using System;
using System.Security.Claims;

namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
	public class Tutor
	{
        public int TutorID { get; set; }
        public string TutorName { get; set; }
        public string AutoAPIID { get; set; }
        public int AccountID { get; set; }
        public string TutorCity { get; set; }
        public string TutorDistrict { get; set; }
        public string TutorWard { get; set; }
        public string TutorBio { get; set; }
        public string TutorSchedule { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}

