using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.Schedule
{
    public class ScheduleBookingViewModel
    {
        public int BookingId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string Description { get; set; } = "";
        public string Status { get; set; } = "Pending";
        public string Address { get; set; } = "";
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CancellationReason { get; set; } = "";
        public ScheduleUserViewModel Student { get; set; }

    }
}
