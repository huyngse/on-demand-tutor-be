

using System;
using System.Collections.Generic;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels 
{

    public class ClassViewModel {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public DateTime ClassTime { get; set; }
        public string ClassInfo { get; set; }
        public string ClassRequire { get; set; }
        public string ClassAddress { get; set; }
        public string ClassMethod { get; set; }
        public string ClassLevel { get; set; }
        public float ClassFee { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Active { get; set; }
        public int TutorId { get; set; }
        public string TutorName { get; set; }
        public int ScheduleId { get; set; }
        public string Feedback { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }

    }

}
