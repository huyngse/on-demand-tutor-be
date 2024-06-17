using System;
using AutoMapper;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Booking;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.User;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.Booking;
using BE_SWP391_OnDemandTutor.DataAccess.Models;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.AutoMapperModule
{
	public static class BookingModule
	{
        public static void ConfigBookingModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Booking, BookingViewModel>().ReverseMap();
            mc.CreateMap<Booking, CreateBookingRequestModel>().ReverseMap();
            mc.CreateMap<Booking, UpdateUserRequestModel>().ReverseMap();
         
        }
    }
}

