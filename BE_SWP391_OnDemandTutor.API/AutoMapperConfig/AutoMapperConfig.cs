using AutoMapper;
using BE_SWP391_OnDemandTutor.BusinessLogic.AutoMapperModule;
using BE_SWP391_OnDemandTutor.BussinessLogic.AutoMapperModule;

namespace BirdCageShop.Presentation.AutoMapperConfig
{
    public static class AutoMapperConfig
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.ConfigAccountModule();
                mc.ConfigClassModule();
                mc.ConfigFeedbackModule();
                mc.ConfigParentModule();
                mc.ConfigScheduleModule();
                mc.ConfigSubjectModule();
                mc.ConfigTutorModule();
            });
            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
