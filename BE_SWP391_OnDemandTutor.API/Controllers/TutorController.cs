using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using Ecommerce.BusinessLogic.RequestModels.Tutor;
using Ecommerce.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BE_SWP391_OnDemandTutor.Presentation.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/tutors")]
    public class TutorController : ControllerBase {

        private ITutorService _tutorService;

         public TutorController(ITutorService tutorService)
        {
            _tutorService = tutorService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<TutorViewModel> CreateTutor(CreateTutorRequestModel tutorCreate)
        {
            var tutorCreated = _tutorService.CreateTutor(tutorCreate);

            if (tutorCreated == null)
            {
                return NotFound("");
            }
            return tutorCreated;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<TutorViewModel>> GetAll()
        {
            var tutorList = _tutorService.GetAll();

            if (tutorList == null)
            {
                return NotFound("");
            }
            return tutorList;
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public ActionResult<TutorViewModel> GetById(int idTmp)
        {
            var tutorDetail = _tutorService.GetById(idTmp);

            if (tutorDetail == null)
            {
                return NotFound("");
            }
            return tutorDetail;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<bool> DeleteTutor(int idTmp)
        {
            var check = _tutorService.DeleteTutor(idTmp);

            if (check == false)
            {
                return NotFound("");
            }
            return check;
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public ActionResult<TutorViewModel> UpdateTutor(UpdateTutorRequestModel tutorCreate)
        {
            var tutorUpdated = _tutorService.UpdateTutor(tutorCreate);

            if (tutorUpdated == null)
            {
                return NotFound("");
            }
            return tutorUpdated;
        }
    }

}
