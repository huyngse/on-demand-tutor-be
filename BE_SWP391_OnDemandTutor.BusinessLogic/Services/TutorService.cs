using BE_SWP391_OnDemandTutor.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Tutor;
using Ecommerce.BusinessLogic.ViewModels;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface ITutorService {
        public TutorViewModel CreateTutor(CreateTutorRequestModel tutorCreate);
        public TutorViewModel UpdateTutor(UpdateTutorRequestModel tutorUpdate);
        public bool DeleteTutor(int idTmp);
        public List<TutorViewModel> GetAll();
        public TutorViewModel GetById(int idTmp);
    }

    public class TutorService : ITutorService {

      private readonly ITutorRepository _tutorRepository;

        public TutorService(ITutorRepository tutorRepository)
        {
            _tutorRepository = tutorRepository;
        }

        public TutorViewModel CreateTutor(CreateTutorRequestModel tutorCreate)
        {
            throw new NotImplementedException();
        }

        public TutorViewModel UpdateTutor(UpdateTutorRequestModel tutorUpdate) 
        {
            throw new NotImplementedException();
        }

        public bool DeleteTutor(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<TutorViewModel> GetAll() 
        {
            throw new NotImplementedException();
        }

        public TutorViewModel GetById(int idTmp) 
        {
            throw new NotImplementedException();
        }

    }

}
