﻿using System;
namespace BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.Booking
{
	public class BookingViewModel
	{
        public int Id { get; set; }
        public int scheduleId { get; set; }
        public int UserId { get; set; }
        public DateTime createDate { get; set; }
        public string description { get; set; }
        public string Address { get; set; }

    }
}

