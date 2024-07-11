﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.User;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.Booking
{
    public class BookingDetailViewModel
    {
        public int BookingId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; } = "";
        public string Address { get; set; } = "";
        public string Status { get; set; } = "";
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public UserViewModel? User { get; set; }
        public TutorViewModel? Tutor { get; set; }
        public BookingScheduleViewModel? Schedule { get; set; }
        public BookingClassViewModel? Class { get; set; }
    }
}
