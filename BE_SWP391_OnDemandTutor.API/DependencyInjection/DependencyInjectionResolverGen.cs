using BE_SWP391_OnDemandTutor.BusinessLogic.Services;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Generations.DependencyInjection
{
    public static class DependencyInjectionResolverGen
    {
        public static void InitializerDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IFirebaseService, FirebaseService>();

            services.AddScoped<IClassService, ClassService>();
        
            services.AddScoped<IFeedbackService, FeedbackService>();
        
            services.AddScoped<IRateService, RateService>();
        
            services.AddScoped<IScheduleService, ScheduleService>();
        
            services.AddScoped<ITutorDegreeService, TutorDegreeService>();
        
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IBookingService, BookingService>();


        }
    }
}
