using BE_SWP391_OnDemandTutor.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.User
{
    public class TutorViewModel
    {
        public int UserId { get; set; }
        public string Username { get; set; } = String.Empty;
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
        public List<TutorDegreeViewModel> TutorDegrees { get; set; }
        public List<TutorBookingViewModel> Bookings { get; set; }
        public List<TutorClassViewModel> Classes { get; set; }
    }
}
