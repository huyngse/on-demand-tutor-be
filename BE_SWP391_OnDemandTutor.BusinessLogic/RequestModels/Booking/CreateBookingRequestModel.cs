using System;
namespace BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Booking
{
	public class CreateBookingRequestModel
	{
        public int UserId { get; set; }
        public int ScheduleId { get; set; }
        public string Description { get; set; } = "";
        public string Address { get; set; } = "";
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

