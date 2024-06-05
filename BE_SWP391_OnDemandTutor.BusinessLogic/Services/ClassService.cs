using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Class;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using System.Linq.Dynamic.Core;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface IClassService
    {
        Task<ClassViewModel> GetDetail(Guid classId);
        Task<bool> UpdateInforClass(UpdateClassRequestModel classUpdate);
        Task<ClassViewModel> CreateClass(CreateClassRequestModel classCreate, Guid userid);
        Task<ClassViewModel> UpdateTranningProgram(int code, Guid classId);
        Task<ClassViewModel> GetById(Guid idTmp);
        //Task<PageResult<ListClassViewModel>> SearchAndFilterClass(SortRequestModel sort, PagingRequestModel paging, SearchRequestModel search, FilterRequestModel filter);
        Task<(bool Success, string ClassName)> DeactivateClass(Guid idTmp);
        //Task<List<SessionViewModel>> CreateSession(Guid classId, CreateSessionRequestModel sessionCreate);
    }

    public class ClassService : IClassService
    {
        private readonly BE_SWP391_OnDemandTutorDbContext _context;

        public ClassService(BE_SWP391_OnDemandTutorDbContext context)
        {
            _context = context;
        }
        Task<ClassViewModel> IClassService.CreateClass(CreateClassRequestModel classCreate, Guid userid)
        {
            throw new NotImplementedException();
        }

        Task<(bool Success, string ClassName)> IClassService.DeactivateClass(Guid idTmp)
        {
            throw new NotImplementedException();
        }

        Task<ClassViewModel> IClassService.GetById(Guid idTmp)
        {
            throw new NotImplementedException();
        }

        Task<ClassViewModel> IClassService.GetDetail(Guid classId)
        {
            throw new NotImplementedException();
        }

        Task<bool> IClassService.UpdateInforClass(UpdateClassRequestModel classUpdate)
        {
            throw new NotImplementedException();
        }

        Task<ClassViewModel> IClassService.UpdateTranningProgram(int code, Guid classId)
        {
            throw new NotImplementedException();
        }
    }

}
