using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using Ecommerce.BusinessLogic.RequestModels.Class;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BE_SWP391_OnDemandTutor.Presentation.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/classs")]
    public class ClassController : ControllerBase
    {

        private IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<ClassViewModel> CreateClass(CreateClassRequestModel classCreate)
        {
            var classCreated = _classService.CreateClass(classCreate);

            if (classCreated == null)
            {
                return NotFound("");
            }
            return classCreated;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<ClassViewModel>> GetAll()
        {
            var classList = _classService.GetAll();

            if (classList == null)
            {
                return NotFound("");
            }
            return classList;
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public ActionResult<ClassViewModel> GetById(int idTmp)
        {
            var classDetail = _classService.GetById(idTmp);

            if (classDetail == null)
            {
                return NotFound("");
            }
            return classDetail;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<bool> DeleteClass(int idTmp)
        {
            var check = _classService.DeleteClass(idTmp);

            if (check == false)
            {
                return NotFound("");
            }
            return check;
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public ActionResult<ClassViewModel> UpdateClass(UpdateClassRequestModel classCreate)
        {
            var classUpdated = _classService.UpdateClass(classCreate);

            if (classUpdated == null)
            {
                return NotFound("");
            }
            return classUpdated;
        }
    }

}
