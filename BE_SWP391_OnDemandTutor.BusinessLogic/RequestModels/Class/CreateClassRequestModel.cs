
using System.ComponentModel.DataAnnotations;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Class 
{

   public class CreateClassRequestModel {
        [Required(ErrorMessage = "Class Name is required")]
        [MaxLength(64, ErrorMessage = "Class Name must be less than 64 characters")]

        public string ClassName { get; set; } = String.Empty;
        public string ClassInfo { get; set; } = String.Empty;
        public string ClassRequire { get; set; } = String.Empty;
        public string ClassAddress { get; set; } = String.Empty;
        public string ClassMethod { get; set; } = String.Empty;
        public string ClassLevel { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; }
        public string City { get; set; } = String.Empty;
        public string District { get; set; } = String.Empty;
        public string Ward { get; set; } = String.Empty;
        public string MeetingLink { get; set; }
        public bool Active { get; set; }
        public float ClassFee { get; set; }
        public int? StudentId { get; set; }
        public int TutorId { get; set; }
    }

}
