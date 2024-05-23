
using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using BE_SWP391_OnDemandTutor.DataAccess.Models;

namespace BE_SWP391_OnDemandTutor.DataAccess.Repositories 
{

    public partial interface IScheduleRepository :IBaseRepository<Schedule>
    {
    }
    public partial class ScheduleRepository :BaseRepository<Schedule>, IScheduleRepository
    {
         public ScheduleRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}


