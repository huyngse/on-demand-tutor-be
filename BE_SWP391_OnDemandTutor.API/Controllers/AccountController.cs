using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using Ecommerce.BusinessLogic.RequestModels.Account;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BE_SWP391_OnDemandTutor.Presentation.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/accounts")]
    public class AccountController : ControllerBase
    {

        private IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<AccountViewModel> CreateAccount(CreateAccountRequestModel accountCreate)
        {
            var accountCreated = _accountService.CreateAccount(accountCreate);

            if (accountCreated == null)
            {
                return NotFound("");
            }
            return accountCreated;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<AccountViewModel>> GetAll()
        {
            var accountList = _accountService.GetAll();

            if (accountList == null)
            {
                return NotFound("");
            }
            return accountList;
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public ActionResult<AccountViewModel> GetById(int idTmp)
        {
            var accountDetail = _accountService.GetById(idTmp);

            if (accountDetail == null)
            {
                return NotFound("");
            }
            return accountDetail;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<bool> DeleteAccount(int idTmp)
        {
            var check = _accountService.DeleteAccount(idTmp);

            if (check == false)
            {
                return NotFound("");
            }
            return check;
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public ActionResult<AccountViewModel> UpdateAccount(UpdateAccountRequestModel accountCreate)
        {
            var accountUpdated = _accountService.UpdateAccount(accountCreate);

            if (accountUpdated == null)
            {
                return NotFound("");
            }
            return accountUpdated;
        }
    }

}
