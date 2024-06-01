using AutoMapper;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Slot;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.DataAccess.Models;


namespace BE_SWP391_OnDemandTutor.BusinessLogic.AutoMapperModule
{

    public static class SlotModule
    {
        public static void ConfigSlotModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Slot, SlotViewModel>().ReverseMap();
            mc.CreateMap<Slot, CreateSlotRequestModel>().ReverseMap();
            mc.CreateMap<Slot, UpdateSlotRequestModel>().ReverseMap();
        }
    }

}
