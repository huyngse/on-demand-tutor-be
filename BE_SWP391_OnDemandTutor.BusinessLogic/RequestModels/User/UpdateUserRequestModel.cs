using Microsoft.AspNetCore.Http;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.User
{
    public class UpdateUserRequestModel
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string Street { get; set; }
    }
}
