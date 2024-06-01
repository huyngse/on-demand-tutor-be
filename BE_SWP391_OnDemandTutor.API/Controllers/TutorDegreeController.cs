using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.TutorDegree;
using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BE_SWP391_OnDemandTutor.Presentation.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/tutordegrees")]
    public class TutorDegreeController : ControllerBase {

        private ITutorDegreeService _tutordegreeService;

         public TutorDegreeController(ITutorDegreeService tutordegreeService)
        {
            _tutordegreeService = tutordegreeService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<TutorDegreeViewModel> CreateTutorDegree(CreateTutorDegreeRequestModel tutordegreeCreate)
        {
            var tutordegreeCreated = _tutordegreeService.CreateTutorDegree(tutordegreeCreate);

            if (tutordegreeCreated == null)
            {
                return NotFound("");
            }
            return tutordegreeCreated;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<TutorDegreeViewModel>> GetAll()
        {
            var tutordegreeList = _tutordegreeService.GetAll();

            if (tutordegreeList == null)
            {
                return NotFound("");
            }
            return tutordegreeList;
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public ActionResult<TutorDegreeViewModel> GetById(int idTmp)
        {
            var tutordegreeDetail = _tutordegreeService.GetById(idTmp);

            if (tutordegreeDetail == null)
            {
                return NotFound("");
            }
            return tutordegreeDetail;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<bool> DeleteTutorDegree(int idTmp)
        {
            var check = _tutordegreeService.DeleteTutorDegree(idTmp);

            if (check == false)
            {
                return NotFound("");
            }
            return check;
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public ActionResult<TutorDegreeViewModel> UpdateTutorDegree(UpdateTutorDegreeRequestModel tutordegreeCreate)
        {
            var tutordegreeUpdated = _tutordegreeService.UpdateTutorDegree(tutordegreeCreate);

            if (tutordegreeUpdated == null)
            {
                return NotFound("");
            }
            return tutordegreeUpdated;
        }
    }

}
