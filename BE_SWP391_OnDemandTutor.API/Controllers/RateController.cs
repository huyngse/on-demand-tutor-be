using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Rate;
using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BE_SWP391_OnDemandTutor.Presentation.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/rates")]
    public class RateController : ControllerBase
    {

        private IRateService _rateService;

        public RateController(IRateService rateService)
        {
            _rateService = rateService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<RateViewModel> CreateRate(CreateRateRequestModel rateCreate)
        {
            var rateCreated = _rateService.CreateRate(rateCreate);

            if (rateCreated == null)
            {
                return NotFound("");
            }
            return rateCreated;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<RateViewModel>> GetAll()
        {
            var rateList = _rateService.GetAll();

            if (rateList == null)
            {
                return NotFound("");
            }
            return rateList;
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public ActionResult<RateViewModel> GetById(int idTmp)
        {
            var rateDetail = _rateService.GetById(idTmp);

            if (rateDetail == null)
            {
                return NotFound("");
            }
            return rateDetail;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<bool> DeleteRate(int idTmp)
        {
            var check = _rateService.DeleteRate(idTmp);

            if (check == false)
            {
                return NotFound("");
            }
            return check;
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public ActionResult<RateViewModel> UpdateRate(UpdateRateRequestModel rateCreate)
        {
            var rateUpdated = _rateService.UpdateRate(rateCreate);

            if (rateUpdated == null)
            {
                return NotFound("");
            }
            return rateUpdated;
        }
    }

}
