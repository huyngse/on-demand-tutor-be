
using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using BE_SWP391_OnDemandTutor.DataAccess.Models;

namespace BE_SWP391_OnDemandTutor.DataAccess.Repositories 
{

    public partial interface ITutorRepository :IBaseRepository<Tutor>
    {
    }
    public partial class TutorRepository :BaseRepository<Tutor>, ITutorRepository
    {
         public TutorRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}


