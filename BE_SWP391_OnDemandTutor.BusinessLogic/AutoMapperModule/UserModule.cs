using AutoMapper;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.User;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.DataAccess.Models;


namespace BE_SWP391_OnDemandTutor.BusinessLogic.AutoMapperModule
{

    public static class UserModule
    {
        public static void ConfigUserModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<User, UserViewModel>().ReverseMap();
            mc.CreateMap<User, RegisterRequestModel>().ReverseMap();
            mc.CreateMap<User, UpdateUserRequestModel>().ReverseMap();
        }
    }

}
