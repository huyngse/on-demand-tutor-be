using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.TutorDegree;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface ITutorDegreeService
    {
        public TutorDegreeViewModel CreateTutorDegree(CreateTutorDegreeRequestModel tutordegreeCreate);
        public TutorDegreeViewModel UpdateTutorDegree(UpdateTutorDegreeRequestModel tutordegreeUpdate);
        public bool DeleteTutorDegree(int idTmp);
        public List<TutorDegreeViewModel> GetAll();
        public TutorDegreeViewModel GetById(int idTmp);
    }

    public class TutorDegreeService : ITutorDegreeService
    {

      
        public TutorDegreeViewModel CreateTutorDegree(CreateTutorDegreeRequestModel tutordegreeCreate)
        {
            throw new NotImplementedException();
        }

        public TutorDegreeViewModel UpdateTutorDegree(UpdateTutorDegreeRequestModel tutordegreeUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTutorDegree(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<TutorDegreeViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public TutorDegreeViewModel GetById(int idTmp)
        {
            throw new NotImplementedException();
        }

    }

}
