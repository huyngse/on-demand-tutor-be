using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Slot;
using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BE_SWP391_OnDemandTutor.Presentation.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/slots")]
    public class SlotController : ControllerBase {

        private ISlotService _slotService;

         public SlotController(ISlotService slotService)
        {
            _slotService = slotService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<SlotViewModel> CreateSlot(CreateSlotRequestModel slotCreate)
        {
            var slotCreated = _slotService.CreateSlot(slotCreate);

            if (slotCreated == null)
            {
                return NotFound("");
            }
            return slotCreated;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<SlotViewModel>> GetAll()
        {
            var slotList = _slotService.GetAll();

            if (slotList == null)
            {
                return NotFound("");
            }
            return slotList;
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public ActionResult<SlotViewModel> GetById(int idTmp)
        {
            var slotDetail = _slotService.GetById(idTmp);

            if (slotDetail == null)
            {
                return NotFound("");
            }
            return slotDetail;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<bool> DeleteSlot(int idTmp)
        {
            var check = _slotService.DeleteSlot(idTmp);

            if (check == false)
            {
                return NotFound("");
            }
            return check;
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public ActionResult<SlotViewModel> UpdateSlot(UpdateSlotRequestModel slotCreate)
        {
            var slotUpdated = _slotService.UpdateSlot(slotCreate);

            if (slotUpdated == null)
            {
                return NotFound("");
            }
            return slotUpdated;
        }
    }

}
