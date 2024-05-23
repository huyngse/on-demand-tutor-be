
using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using BE_SWP391_OnDemandTutor.DataAccess.Models;

namespace BE_SWP391_OnDemandTutor.DataAccess.Repositories 
{

    public partial interface IParentRepository :IBaseRepository<Parent>
    {
    }
    public partial class ParentRepository :BaseRepository<Parent>, IParentRepository
    {
         public ParentRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}


