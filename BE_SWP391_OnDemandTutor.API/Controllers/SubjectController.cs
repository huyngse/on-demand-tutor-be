using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Subject;
using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BE_SWP391_OnDemandTutor.Presentation.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/subjects")]
    public class SubjectController : ControllerBase
    {

        private ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [MapToApiVersion("1")]
        [HttpPost]
        public ActionResult<SubjectViewModel> CreateSubject(CreateSubjectRequestModel subjectCreate)
        {
            var subjectCreated = _subjectService.CreateSubject(subjectCreate);

            if (subjectCreated == null)
            {
                return NotFound("");
            }
            return subjectCreated;
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public ActionResult<List<SubjectViewModel>> GetAll()
        {
            var subjectList = _subjectService.GetAll();

            if (subjectList == null)
            {
                return NotFound("");
            }
            return subjectList;
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public ActionResult<SubjectViewModel> GetById(int idTmp)
        {
            var subjectDetail = _subjectService.GetById(idTmp);

            if (subjectDetail == null)
            {
                return NotFound("");
            }
            return subjectDetail;
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public ActionResult<bool> DeleteSubject(int idTmp)
        {
            var check = _subjectService.DeleteSubject(idTmp);

            if (check == false)
            {
                return NotFound("");
            }
            return check;
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public ActionResult<SubjectViewModel> UpdateSubject(UpdateSubjectRequestModel subjectCreate)
        {
            var subjectUpdated = _subjectService.UpdateSubject(subjectCreate);

            if (subjectUpdated == null)
            {
                return NotFound("");
            }
            return subjectUpdated;
        }
    }

}
