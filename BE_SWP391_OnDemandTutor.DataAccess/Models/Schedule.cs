using System;
namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }       
        public List<Booking> Bookings { get; set; }
        public Class Class { get; set; }
    }
}

