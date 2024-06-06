
namespace BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels 
{

    public class ScheduleViewModel
    {
        public int ScheduleID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

}
