using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.User
{
    public class UpdateTutorProfileRequestModel
    {
        public string Password { get; set; } = "123456";
        public string FullName { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = "Male";
        public string City { get; set; } = String.Empty;
        public string District { get; set; } = String.Empty;
        public string Ward { get; set; } = String.Empty;
        public string Street { get; set; } = String.Empty;
        public string TutorType { get; set; } = String.Empty;
        public string School { get; set; } = String.Empty;
        public string TutorDescription { get; set; } = String.Empty;
    }
}
