using BE_SWP391_OnDemandTutor.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.Booking
{
    public class BookingClassViewModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public string ClassInfo { get; set; } = string.Empty;
        public string ClassRequire { get; set; } = string.Empty;
        public string ClassMethod { get; set; } = string.Empty;
        public string ClassLevel { get; set; } = string.Empty; 
        public DateTime CreatedDate { get; set; }
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Ward { get; set; } = string.Empty;
        public bool Active { get; set; }
        public float ClassFee { get; set; }
    }
}
