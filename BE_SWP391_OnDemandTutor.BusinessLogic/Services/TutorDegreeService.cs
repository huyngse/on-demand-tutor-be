using AutoMapper;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Schedule;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.TutorDegree;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
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

        public TutorDegreeService(BE_SWP391_OnDemandTutorDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<TutorDegreeViewModel> CreateTutorDegree(CreateTutorDegreeRequestModel degreeCreate)
        {

            //var degree = new TutorDegree
            //{
            //    DegreeName = degreeCreate.DegreeName,   
            //    Description = degreeCreate.Description,
            //    DegreeImageUrl = degreeCreate.DegreeImageUrl,
            //    TutorId = degreeCreate.TutorId,
            //};
            var degree = degreeCreate.Adapt<TutorDegree>();
            _context.TutorDegrees.Add(degree);
            await _context.SaveChangesAsync();
            //return _mapper.Map<TutorDegreeViewModel>(degree);
            return degree.Adapt<TutorDegreeViewModel>();
        }

        public async Task<TutorDegreeViewModel> UpdateDegree(UpdateTutorDegreeRequestModel updateTutor)
        {
            var update = await _context.TutorDegrees.FindAsync(updateTutor.DegreeId);
            if (update == null)
            {
                return null;
            }

            update.Description = updateTutor.Description;
            update.DegreeName = updateTutor.DegreeName;

            await _context.SaveChangesAsync();
            return update.Adapt<TutorDegreeViewModel>();


        }

        public async Task<bool> DeleteTutorDegree(int idTmp)
        {
            var delete = await _context.TutorDegrees.FindAsync(idTmp);
            if (delete == null)
            {
                return false;
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
                return null;
            }
            return degree.Adapt<TutorDegreeViewModel>();


        }

    }

}
