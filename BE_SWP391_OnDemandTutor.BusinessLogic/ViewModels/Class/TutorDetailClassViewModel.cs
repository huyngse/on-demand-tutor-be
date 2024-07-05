using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.Class
{
    public class TutorDetailClassViewModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassInfo { get; set; }
        public string ClassRequire { get; set; }
        public string ClassAddress { get; set; }
        public string ClassMethod { get; set; }
        public string ClassLevel { get; set; }
        public float ClassFee { get; set; }
        public string? StudentName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Active { get; set; }
        public string TutorName { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string City { get; set; }
        public List<ScheduleViewModel> Schedules { get; set; }
    }
}
