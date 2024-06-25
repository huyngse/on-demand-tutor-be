using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.Booking;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.Schedule
{
    public class ScheduleDetailViewModel
    {
        public int ScheduleID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int ClassID { get; set; }
        public DayGroup DateOfWeek { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public List<ScheduleBookingViewModel> Bookings { get; set; } = [];
    }
}
