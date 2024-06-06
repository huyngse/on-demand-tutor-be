

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
        public int TutorId { get; set; }
        public int ScheduleId { get; set; }
    }

}
