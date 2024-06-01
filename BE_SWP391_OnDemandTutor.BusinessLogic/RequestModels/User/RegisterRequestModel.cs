namespace BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.User
{
    public class RegisterRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ProfileImage { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
    }
}
