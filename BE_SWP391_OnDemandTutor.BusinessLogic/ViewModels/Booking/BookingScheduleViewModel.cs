using BE_SWP391_OnDemandTutor.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.Booking
{
    public class BookingScheduleViewModel
    {
        public int ScheduleID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DayGroup DateOfWeek { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
