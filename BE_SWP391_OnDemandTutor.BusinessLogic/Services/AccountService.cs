using BE_SWP391_OnDemandTutor.DataAccess.Repositories;
using Ecommerce.BusinessLogic.RequestModels.Account;
using Ecommerce.BusinessLogic.ViewModels;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface IAccountService
    {
        public AccountViewModel CreateAccount(CreateAccountRequestModel accountCreate);
        public AccountViewModel UpdateAccount(UpdateAccountRequestModel accountUpdate);
        public bool DeleteAccount(int idTmp);
        public List<AccountViewModel> GetAll();
        public AccountViewModel GetById(int idTmp);
    }

    public class AccountService : IAccountService
    {

        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public AccountViewModel CreateAccount(CreateAccountRequestModel accountCreate)
        {
            throw new NotImplementedException();
        }

        public AccountViewModel UpdateAccount(UpdateAccountRequestModel accountUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAccount(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<AccountViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public AccountViewModel GetById(int idTmp)
        {
            throw new NotImplementedException();
        }

    }

}
