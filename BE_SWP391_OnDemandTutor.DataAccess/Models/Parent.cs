using System;


namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
	public class Parent
	{
        public Guid StudentID { get; set; }
        public string StudentName { get; set; }
        public Guid AccountID { get; set; }
        public Guid StudentAge { get; set; }
        public string StudentLevel { get; set; }

        public Account Account { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<ClassParent> ClassParents { get; set; }
    }
}

