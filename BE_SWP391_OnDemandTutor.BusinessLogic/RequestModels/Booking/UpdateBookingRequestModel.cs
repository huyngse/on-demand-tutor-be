
namespace BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Booking
{

    public class UpdateBookingViewModel
    {
        public string Description { get; set; } = "";
        public string Address { get; set; } = "";
        public string Status { get; set; } = "";
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

}
