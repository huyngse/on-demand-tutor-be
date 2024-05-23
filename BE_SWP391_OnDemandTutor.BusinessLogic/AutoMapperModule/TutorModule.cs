using AutoMapper;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Ecommerce.BusinessLogic.RequestModels.Tutor;
using Ecommerce.BusinessLogic.ViewModels;


namespace BE_SWP391_OnDemandTutor.BussinessLogic.AutoMapperModule
{

    public static class TutorModule
    {
        public static void ConfigTutorModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Tutor, TutorViewModel>().ReverseMap();
            mc.CreateMap<Tutor, CreateTutorRequestModel>().ReverseMap();
            mc.CreateMap<Tutor, UpdateTutorRequestModel>().ReverseMap();
        }
    }

}
