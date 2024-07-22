using System;
namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
    public enum DayGroup
    {
        MonWedFri, // Thứ 2, 4, 6
        TueThuSat,  // Thứ 3, 5, 7
        MonWedFriSun //Thứ 2, 4, 6, chủ nhật
    }
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DayGroup DateOfWeek { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public List<Booking> Bookings { get; set; }
        public Class Class { get; set; }
        public int ClassID { get; set; }
    }
}

