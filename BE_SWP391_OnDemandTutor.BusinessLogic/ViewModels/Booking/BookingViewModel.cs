using System;
namespace BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.Booking
{
	public class BookingModel
	{
        public int id { get; set; }
        public int scheduleId { get; set; }
        public int UserId { get; set; }
        public DateTime createDate { get; set; }
        public string description { get; set; }

    }
}

