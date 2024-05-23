using AutoMapper;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Ecommerce.BusinessLogic.RequestModels.Account;
using Ecommerce.BusinessLogic.ViewModels;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.AutoMapperModule
{

    public static class AccountModule
    {
        public static void ConfigAccountModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Account, AccountViewModel>().ReverseMap();
            mc.CreateMap<Account, CreateAccountRequestModel>().ReverseMap();
            mc.CreateMap<Account, UpdateAccountRequestModel>().ReverseMap();
        }
    }

}
