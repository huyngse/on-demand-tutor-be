using AutoMapper;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Ecommerce.BusinessLogic.RequestModels.Subject;
using Ecommerce.BusinessLogic.ViewModels;


namespace BE_SWP391_OnDemandTutor.BusinessLogic.AutoMapperModule
{

    public static class SubjectModule
    {
        public static void ConfigSubjectModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Subject, SubjectViewModel>().ReverseMap();
            mc.CreateMap<Subject, CreateSubjectRequestModel>().ReverseMap();
            mc.CreateMap<Subject, UpdateSubjectRequestModel>().ReverseMap();
        }
    }

}
