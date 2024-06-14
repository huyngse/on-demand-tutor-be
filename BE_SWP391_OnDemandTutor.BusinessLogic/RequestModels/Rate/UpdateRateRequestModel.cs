
namespace BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Rate
{

    public class UpdateRateRequestModel
    {
        public int RatingId { get; set; }
        public int StudentId { get; set; }
        public int TutorId { get; set; }
        public int NumberStars { get; set; }
        public int SubjectId { get; set; }

    }

}