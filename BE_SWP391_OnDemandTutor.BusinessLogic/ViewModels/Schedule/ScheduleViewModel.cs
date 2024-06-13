
using BE_SWP391_OnDemandTutor.DataAccess.Models;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels
{

    public class ScheduleViewModel
    {
        public int ScheduleID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DayGroup DateOfWeek { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }

}