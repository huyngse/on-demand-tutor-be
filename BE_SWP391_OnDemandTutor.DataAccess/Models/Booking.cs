using System;
namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
	public class Booking
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int ScheduleId { get; set; }
		public DateTime CreateDate { get; set; }
		public string Description { get; set; }
		public bool Status { get; set; }

		public User User { get; set; }
		public Schedule Schedule { get; set; }
	}
}

