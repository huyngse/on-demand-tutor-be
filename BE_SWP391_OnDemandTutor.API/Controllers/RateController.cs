using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Rate;
using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BE_SWP391_OnDemandTutor.Common.Paging;
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
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<RateViewModel>> CreateRateAsync(CreateRateRequestModel rateCreate)
        {
            try
            {
                var createdRate = await _rateService.CreateRateAsync(rateCreate);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = createdRate.RatingId }, createdRate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public async Task<ActionResult<List<RateViewModel>>> GetAllAsync([FromQuery] PagingSizeModel paging)
        {
            var rate = await _rateService.GetAll(paging);
            if (rate == null)
            {
                return NotFound("");
            }
            return Ok(rate);
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public async Task<IActionResult> GetByIdAsync(int idTmp)
        {
            var rate = await _rateService.GetById(idTmp);
            if (rate == null)
            {
                return NotFound();
            }

            return Ok(rate);
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteRateAsync(int idTmp)
        {
            var delete = await _rateService.DeleteRate(idTmp);
            if (!delete)
            {
                return NotFound();
            }

            return Ok(new { Message = $"Rate with ID '{idTmp}' deleted successfully." });
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public async Task<ActionResult<RateViewModel>> UpdateRateAsync(int id, UpdateRateRequestModel rateUpdate)
        {
            if (id != rateUpdate.RatingId)
            {
                return BadRequest("ID in the request body does not match the route parameter.");
            }

            var updateRate = await _rateService.UpdateRate(rateUpdate);
            if (updateRate == null)
            {
                return NotFound();
            }

            return Ok(updateRate);
        }
    }

}