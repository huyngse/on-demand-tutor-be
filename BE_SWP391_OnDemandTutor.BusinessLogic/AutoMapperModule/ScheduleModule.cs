using AutoMapper;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Schedule;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.DataAccess.Models;


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
