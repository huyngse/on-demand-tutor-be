﻿namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string ProfileImage { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string Street { get; set; }
        public string TutorType { get; set; }
        public string School { get; set; }
        public string TutorDescription { get; set; }

        public TutorDegree TutorDegree { get; set; }
        public List<Rate> StudentSendRatings { get; set; }
        public List<Rate> TutorReceiveRatings { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        public List<Booking> Bookings { get; set; }
        public ICollection<Class> StudentClasses { get; set; }
        public ICollection<Class> TutorClasses { get; set; }
    }
}
