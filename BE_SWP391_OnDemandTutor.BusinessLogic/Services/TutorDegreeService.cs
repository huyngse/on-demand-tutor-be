using AutoMapper;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Schedule;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.TutorDegree;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using OnDemandTutor.DataAccess.ExceptionModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface ITutorDegreeService
    {
        Task<TutorDegreeViewModel> GetById(int idTmp);
        Task<List<TutorDegreeViewModel>> GetAll();
        Task<TutorDegreeViewModel> CreateTutorDegree(CreateTutorDegreeRequestModel scheduleCreate);
        Task<TutorDegreeViewModel> UpdateDegree(UpdateTutorDegreeRequestModel scheduleUpdate);
        Task<bool> DeleteTutorDegree(int idTmp);
    }

    public class TutorDegreeService : ITutorDegreeService
    {
        private readonly BE_SWP391_OnDemandTutorDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFirebaseService _firebaseService;

        public TutorDegreeService(BE_SWP391_OnDemandTutorDbContext context, IMapper mapper, IFirebaseService firebaseService)
        {
            _context = context;
            _mapper = mapper;
            _firebaseService = firebaseService;
        }


        public async Task<TutorDegreeViewModel> CreateTutorDegree(CreateTutorDegreeRequestModel degreeCreate)
        {
            var degree = degreeCreate.Adapt<TutorDegree>();
            degree.DegreeImageUrl = await _firebaseService.UpdloadTutorDegree(degreeCreate.DegreeImageUrl);
            _context.TutorDegrees.Add(degree);
            await _context.SaveChangesAsync();
            return degree.Adapt<TutorDegreeViewModel>();
        }

        public async Task<TutorDegreeViewModel> UpdateDegree(UpdateTutorDegreeRequestModel updateTutor)
        {
            var update = await _context.TutorDegrees.FindAsync(updateTutor.DegreeId);
            if (update == null)
            {
                throw new NotFoundException("Can not find the Degree");
            }

            update.Description = updateTutor.Description;
            update.DegreeName = updateTutor.DegreeName;
            update.DegreeImageUrl = await _firebaseService.UpdloadTutorDegree(updateTutor.DegreeImageUrl);

            await _context.SaveChangesAsync();
            return update.Adapt<TutorDegreeViewModel>();


        }

        public async Task<bool> DeleteTutorDegree(int idTmp)
        {
            var delete = await _context.TutorDegrees.FindAsync(idTmp);
            if (delete == null)
            {
                throw new NotFoundException("Can not find the Degree");
            }

            _context.TutorDegrees.Remove(delete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<TutorDegreeViewModel>> GetAll()
        {
            var degree = await _context.TutorDegrees.ToListAsync();

            return degree.Adapt<List<TutorDegreeViewModel>>();
        }

        public async Task<TutorDegreeViewModel> GetById(int idTmp)
        {
            var degree = await _context.TutorDegrees.FindAsync(idTmp);
            if (degree == null)
            {
                throw new NotFoundException("Can not find the Degree");
            }
            return degree.Adapt<TutorDegreeViewModel>();


        }

    }

}
