namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = "123456";
        public string FullName { get; set; } = String.Empty;
        public string ProfileImage { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public string EmailAddress { get; set; } = String.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = "Male";
        public string Role { get; set; } = "Student";
        public string City { get; set; } = String.Empty;
        public string District { get; set; } = String.Empty;
        public string Ward { get; set; } = String.Empty;
        public string Street { get; set; } = String.Empty;
        public string TutorType { get; set; } = String.Empty;
        public string School { get; set; } = String.Empty;
        public string TutorDescription { get; set; } = String.Empty;
        public bool IsActive { get; set; }

        public TutorDegree TutorDegree { get; set; }
        public List<Rate> StudentSendRatings { get; set; }
        public List<Rate> TutorReceiveRatings { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        public List<Booking> Bookings { get; set; }
        public ICollection<Class> StudentClasses { get; set; }
        public ICollection<Class> TutorClasses { get; set; }
    }
}
