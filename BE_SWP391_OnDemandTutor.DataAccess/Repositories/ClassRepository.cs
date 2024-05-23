
using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using BE_SWP391_OnDemandTutor.DataAccess.Models;

namespace BE_SWP391_OnDemandTutor.DataAccess.Repositories 
{

    public partial interface IClassRepository :IBaseRepository<Class>
    {
    }
    public partial class ClassRepository :BaseRepository<Class>, IClassRepository
    {
         public ClassRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}


