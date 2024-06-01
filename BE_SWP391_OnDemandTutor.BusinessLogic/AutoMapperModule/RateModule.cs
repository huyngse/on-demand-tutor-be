using AutoMapper;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Rate;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.DataAccess.Models;


namespace BE_SWP391_OnDemandTutor.BusinessLogic.AutoMapperModule
{

    public static class RateModule
    {
        public static void ConfigRateModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Rate, RateViewModel>().ReverseMap();
            mc.CreateMap<Rate, CreateRateRequestModel>().ReverseMap();
            mc.CreateMap<Rate, UpdateRateRequestModel>().ReverseMap();
        }
    }

}
