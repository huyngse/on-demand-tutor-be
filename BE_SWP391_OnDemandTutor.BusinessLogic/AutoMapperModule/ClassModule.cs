using AutoMapper;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Class;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.DataAccess.Models;


namespace BE_SWP391_OnDemandTutor.BusinessLogic.AutoMapperModule
{

    public static class ClassModule
    {
        public static void ConfigClassModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Class, ClassViewModel>().ReverseMap();
            mc.CreateMap<Class, CreateClassRequestModel>().ReverseMap();
            mc.CreateMap<Class, UpdateClassRequestModel>().ReverseMap();
        }
    }

}
