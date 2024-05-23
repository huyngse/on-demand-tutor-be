using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using BE_SWP391_OnDemandTutor.DataAccess.Data;
using BE_SWP391_OnDemandTutor.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Generations.DependencyInjection
{
    public static class DependencyInjectionResolverGen
    {
        public static void InitializerDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<DbContext, DataContext>();
        
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountRepository, AccountRepository>();
        
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IClassRepository, ClassRepository>();
        
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
        
            services.AddScoped<IParentService, ParentService>();
            services.AddScoped<IParentRepository, ParentRepository>();
        
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
        
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
        
            services.AddScoped<ITutorService, TutorService>();
            services.AddScoped<ITutorRepository, TutorRepository>();
        }
    }
}
