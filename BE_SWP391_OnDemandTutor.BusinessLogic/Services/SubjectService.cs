using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Subject;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;

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
