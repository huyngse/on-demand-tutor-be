using BE_SWP391_OnDemandTutor.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Class;
using Ecommerce.BusinessLogic.ViewModels;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface IClassService
    {
        public ClassViewModel CreateClass(CreateClassRequestModel classCreate);
        public ClassViewModel UpdateClass(UpdateClassRequestModel classUpdate);
        public bool DeleteClass(int idTmp);
        public List<ClassViewModel> GetAll();
        public ClassViewModel GetById(int idTmp);
    }

    public class ClassService : IClassService
    {

        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public ClassViewModel CreateClass(CreateClassRequestModel classCreate)
        {
            throw new NotImplementedException();
        }

        public ClassViewModel UpdateClass(UpdateClassRequestModel classUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeleteClass(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<ClassViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ClassViewModel GetById(int idTmp)
        {
            throw new NotImplementedException();
        }

    }

}
