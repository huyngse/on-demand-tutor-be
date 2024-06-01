using System;
namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
	public class Account
	{
        public Guid AccountID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ProfileImage { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        public Tutor Tutor { get; set; }
        public Parent Parent { get; set; }

        public ICollection<Tutor> Tutors { get; set; }
        public ICollection<Parent> Parents { get; set; }


    }
} 

