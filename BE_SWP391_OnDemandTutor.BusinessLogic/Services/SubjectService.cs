using BE_SWP391_OnDemandTutor.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Subject;
using Ecommerce.BusinessLogic.ViewModels;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface ISubjectService
    {
        public SubjectViewModel CreateSubject(CreateSubjectRequestModel subjectCreate);
        public SubjectViewModel UpdateSubject(UpdateSubjectRequestModel subjectUpdate);
        public bool DeleteSubject(int idTmp);
        public List<SubjectViewModel> GetAll();
        public SubjectViewModel GetById(int idTmp);
    }

    public class SubjectService : ISubjectService
    {

        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public SubjectViewModel CreateSubject(CreateSubjectRequestModel subjectCreate)
        {
            throw new NotImplementedException();
        }

        public SubjectViewModel UpdateSubject(UpdateSubjectRequestModel subjectUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSubject(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<SubjectViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public SubjectViewModel GetById(int idTmp)
        {
            throw new NotImplementedException();
        }

    }

}
