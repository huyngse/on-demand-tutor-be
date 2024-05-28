using System;
using System.Security.Claims;

namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
	public class Tutor
	{
        public int TutorID { get; set; }
        public string TutorName { get; set; }
        public int AccountID { get; set; }
        public string TutorCity { get; set; }
        public string TutorDistrict { get; set; }
        public string TutorWard { get; set; }
        public string TutorStreet { get; set; }

        public Account Account { get; set; }
        public Schedule Schedule { get; set; }
        public ICollection<Class> Classes { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}

