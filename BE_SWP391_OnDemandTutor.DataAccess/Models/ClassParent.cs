using System;
namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
	public class ClassParent
	{
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
    }
}

