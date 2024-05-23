



using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using NTQ.Sdk.Core.BaseConnect;

namespace BE_SWP391_OnDemandTutor.DataAccess.Repositories
{

    public partial interface IAccountRepository :IBaseRepository<Account>
    {
    }
    public partial class AccountRepository :BaseRepository<Account>, IAccountRepository
    {
         public AccountRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}


