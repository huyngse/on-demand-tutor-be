namespace BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
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
        public string TutorDescription { get; set; }
        public string School { get; set; }
        public bool IsActive { get; set; }
    }
}
