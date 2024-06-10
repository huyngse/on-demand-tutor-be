
using System.ComponentModel.DataAnnotations;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Class 
{

   public class UpdateClassRequestModel {
        public int ClassId { get; set; }

        [Required(ErrorMessage = "Class Name is required")]
        [MaxLength(64, ErrorMessage = "Class Name must be less than 64 characters")]
        public string ClassName { get; set; }
        public DateTime ClassTime { get; set; }
        public string ClassInfo { get; set; }
        public string ClassRequire { get; set; }
        public string ClassAddress { get; set; }
        public string ClassMethod { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Active { get; set; }
        public string ClassLevel { get; set; }
        public float ClassFee { get; set; }
        public int StudentId { get; set; }
        public int TutorId { get; set; }
        public int ScheduleId { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string City { get; set; }
    }

}
