using AutoMapper;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Ecommerce.BusinessLogic.RequestModels.Class;
using Ecommerce.BusinessLogic.ViewModels;


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
