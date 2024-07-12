using Mapster;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Rate;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using OnDemandTutor.DataAccess.ExceptionModels;
using BE_SWP391_OnDemandTutor.Common.Paging;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface IRateService
    {
        Task<RateViewModel> CreateRateAsync(CreateRateRequestModel rateCreate);
        Task<RateViewModel> UpdateRate(UpdateRateRequestModel rateUpdate);
        Task<bool> DeleteRate(int idTmp);
        Task<List<RateViewModel>> GetAll(PagingSizeModel paging);
        Task<RateViewModel> GetById(int idTmp);
    }

    public class RateService : IRateService
    {
        private readonly BE_SWP391_OnDemandTutorDbContext _context;

        public RateService(BE_SWP391_OnDemandTutorDbContext context)
        {
            _context = context;
        }



        public async Task<RateViewModel> CreateRateAsync(CreateRateRequestModel rateCreate)
        {
            var Rate = rateCreate.Adapt<Rate>();
            _context.Rates.Add(Rate);
            await _context.SaveChangesAsync();
            return Rate.Adapt<RateViewModel>();
        }



        public async Task<RateViewModel> UpdateRate(UpdateRateRequestModel rateUpdate)
        {
            var update = await _context.Rates.FindAsync(rateUpdate.RatingId);
            if (update == null)
            {
                throw new NotFoundException("Can not find the Rate to upddate");
            }
            update.NumberStars = rateUpdate.NumberStars;


            return update.Adapt<RateViewModel>();
        }

        public async Task<bool> DeleteRate(int idTmp)
        {
            var delete = await _context.Rates.FindAsync(idTmp);
            if (delete == null)
            {
                throw new NotFoundException("Can not find the Rate to delete");
            }

            _context.Rates.Remove(delete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<RateViewModel>> GetAll(PagingSizeModel paging)
        {
            var rate = await _context.Rates.ToListAsync();
            return rate.Skip((paging.Page - 1) * paging.Limit).Take(paging.Limit).Select(rate=> rate.Adapt<RateViewModel>()).ToList();
        }

        public async Task<RateViewModel> GetById(int idTmp)
        {
            var rate = await _context.Rates.FindAsync(idTmp);
            if (rate == null)
            {
                throw new NotFoundException("Can not find the Rate");
            }

            return rate.Adapt<RateViewModel>();
        }
    }



}