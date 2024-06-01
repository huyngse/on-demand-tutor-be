using AutoMapper;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Feedback;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.DataAccess.Models;


namespace BE_SWP391_OnDemandTutor.BusinessLogic.AutoMapperModule
{

    public static class FeedbackModule
    {
        public static void ConfigFeedbackModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Feedback, FeedbackViewModel>().ReverseMap();
            mc.CreateMap<Feedback, CreateFeedbackRequestModel>().ReverseMap();
            mc.CreateMap<Feedback, UpdateFeedbackRequestModel>().ReverseMap();
        }
    }

}
