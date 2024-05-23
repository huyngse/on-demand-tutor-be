using BE_SWP391_OnDemandTutor.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Parent;
using Ecommerce.BusinessLogic.ViewModels;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface IParentService
    {
        public ParentViewModel CreateParent(CreateParentRequestModel parentCreate);
        public ParentViewModel UpdateParent(UpdateParentRequestModel parentUpdate);
        public bool DeleteParent(int idTmp);
        public List<ParentViewModel> GetAll();
        public ParentViewModel GetById(int idTmp);
    }

    public class ParentService : IParentService
    {

        private readonly IParentRepository _parentRepository;

        public ParentService(IParentRepository parentRepository)
        {
            _parentRepository = parentRepository;
        }

        public ParentViewModel CreateParent(CreateParentRequestModel parentCreate)
        {
            throw new NotImplementedException();
        }

        public ParentViewModel UpdateParent(UpdateParentRequestModel parentUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeleteParent(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<ParentViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ParentViewModel GetById(int idTmp)
        {
            throw new NotImplementedException();
        }

    }

}
