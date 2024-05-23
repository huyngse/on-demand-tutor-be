using System;


namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
	public class Parent
	{
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int AccountID { get; set; }
        public int StudentAge { get; set; }
        public string StudentLevel { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}

