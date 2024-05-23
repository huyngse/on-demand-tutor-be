using AutoMapper;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Ecommerce.BusinessLogic.RequestModels.Schedule;
using Ecommerce.BusinessLogic.ViewModels;


namespace BE_SWP391_OnDemandTutor.BusinessLogic.AutoMapperModule
{

    public static class ScheduleModule
    {
        public static void ConfigScheduleModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Schedule, ScheduleViewModel>().ReverseMap();
            mc.CreateMap<Schedule, CreateScheduleRequestModel>().ReverseMap();
            mc.CreateMap<Schedule, UpdateScheduleRequestModel>().ReverseMap();
        }
    }

}
