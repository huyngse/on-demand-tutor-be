using AutoMapper;
using BE_SWP391_OnDemandTutor.BusinessLogic.AutoMapperModule;

namespace BE_SWP391_OnDemandTutor.API.AutoMapperConfig
{
    public static class AutoMapperConfig
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.ConfigClassModule();
                mc.ConfigFeedbackModule();
                mc.ConfigRateModule();
                mc.ConfigScheduleModule();
                mc.ConfigTutorDegreeModule();
                mc.ConfigUserModule();

            });
            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
