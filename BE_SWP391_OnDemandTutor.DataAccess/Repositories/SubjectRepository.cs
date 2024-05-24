
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;

namespace BE_SWP391_OnDemandTutor.DataAccess.Repositories
{

    public partial interface ISubjectRepository : IBaseRepository<Subject>
    {
    }
    public partial class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}