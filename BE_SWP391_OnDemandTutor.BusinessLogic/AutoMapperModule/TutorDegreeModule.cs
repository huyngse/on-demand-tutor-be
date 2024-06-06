using AutoMapper;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.TutorDegree;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.DataAccess.Models;


namespace BE_SWP391_OnDemandTutor.BusinessLogic.AutoMapperModule
{

    public static class TutorDegreeModule
    {
        public static void ConfigTutorDegreeModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<TutorDegree, TutorDegreeViewModel>().ReverseMap();
            mc.CreateMap<TutorDegree, CreateTutorDegreeRequestModel>().ReverseMap();
            mc.CreateMap<TutorDegree, UpdateTutorDegreeRequestModel>().ReverseMap();
        }
    }

}
