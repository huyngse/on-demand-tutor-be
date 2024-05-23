using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using Ecommerce.BusinessLogic.RequestModels.Parent;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BE_SWP391_OnDemandTutor.Presentation.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/parents")]
    public class ParentController : ControllerBase
    {

        private IParentService _parentService;

        public ParentController(IParentService parentService)
        {
            _parentService = parentService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<ParentViewModel> CreateParent(CreateParentRequestModel parentCreate)
        {
            var parentCreated = _parentService.CreateParent(parentCreate);

            if (parentCreated == null)
            {
                return NotFound("");
            }
            return parentCreated;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<ParentViewModel>> GetAll()
        {
            var parentList = _parentService.GetAll();

            if (parentList == null)
            {
                return NotFound("");
            }
            return parentList;
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public ActionResult<ParentViewModel> GetById(int idTmp)
        {
            var parentDetail = _parentService.GetById(idTmp);

            if (parentDetail == null)
            {
                return NotFound("");
            }
            return parentDetail;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<bool> DeleteParent(int idTmp)
        {
            var check = _parentService.DeleteParent(idTmp);

            if (check == false)
            {
                return NotFound("");
            }
            return check;
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public ActionResult<ParentViewModel> UpdateParent(UpdateParentRequestModel parentCreate)
        {
            var parentUpdated = _parentService.UpdateParent(parentCreate);

            if (parentUpdated == null)
            {
                return NotFound("");
            }
            return parentUpdated;
        }
    }

}
