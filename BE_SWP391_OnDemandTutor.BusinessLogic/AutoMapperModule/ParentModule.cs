using AutoMapper;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Ecommerce.BusinessLogic.RequestModels.Parent;
using Ecommerce.BusinessLogic.ViewModels;


namespace BE_SWP391_OnDemandTutor.BusinessLogic.AutoMapperModule
{

    public static class ParentModule
    {
        public static void ConfigParentModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Parent, ParentViewModel>().ReverseMap();
            mc.CreateMap<Parent, CreateParentRequestModel>().ReverseMap();
            mc.CreateMap<Parent, UpdateParentRequestModel>().ReverseMap();
        }
    }

}
