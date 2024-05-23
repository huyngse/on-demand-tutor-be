
using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;
using BE_SWP391_OnDemandTutor.DataAccess.Models;

namespace BE_SWP391_OnDemandTutor.DataAccess.Repositories 
{

    public partial interface IFeedbackRepository :IBaseRepository<Feedback>
    {
    }
    public partial class FeedbackRepository :BaseRepository<Feedback>, IFeedbackRepository
    {
         public FeedbackRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}


