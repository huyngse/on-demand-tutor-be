using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Rate;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface IRateService
    {
        public RateViewModel CreateRate(CreateRateRequestModel rateCreate);
        public RateViewModel UpdateRate(UpdateRateRequestModel rateUpdate);
        public bool DeleteRate(int idTmp);
        public List<RateViewModel> GetAll();
        public RateViewModel GetById(int idTmp);
    }

    public class RateService : IRateService
    {

      

        public RateViewModel CreateRate(CreateRateRequestModel rateCreate)
        {
            throw new NotImplementedException();
        }

        public RateViewModel UpdateRate(UpdateRateRequestModel rateUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRate(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<RateViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public RateViewModel GetById(int idTmp)
        {
            throw new NotImplementedException();
        }

    }

}
