
namespace BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Booking
{

    public class UpdateBookingViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ScheduleId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string Address { get; set; }


    }

}
