using System;
namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
	public class Booking
	{
		public int BookingId { get; set; }
		public int UserId { get; set; }
		public int ScheduleId { get; set; }
		public DateTime CreateDate { get; set; } = DateTime.Now;
        public string Description { get; set; } = "";
		public string Status { get; set; } = "Pending";
		public string Address { get; set; } = "";
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public User? User { get; set; }
		public Schedule? Schedule { get; set; }
        public string CancellationReason { get; set; }
        public bool IsCancelled { get; set; }
    }
}

