using AutoMapper;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.TutorFreeTimeSchedule;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.DataAccess.Models;


namespace BE_SWP391_OnDemandTutor.BusinessLogic.AutoMapperModule
{

    public static class TutorFreeTimeScheduleModule
    {
        public static void ConfigTutorFreeTimeScheduleModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<TutorFreeTimeSchedule, TutorFreeTimeScheduleViewModel>().ReverseMap();
            mc.CreateMap<TutorFreeTimeSchedule, CreateTutorFreeTimeScheduleRequestModel>().ReverseMap();
            mc.CreateMap<TutorFreeTimeSchedule, UpdateTutorFreeTimeScheduleRequestModel>().ReverseMap();
        }
    }

}
