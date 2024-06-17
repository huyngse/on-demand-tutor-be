﻿using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Booking;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Feedback;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.Booking;
using BE_SWP391_OnDemandTutor.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Mapster;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Rate;
namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

	public interface IBookingService
	{
        Task<BookingViewModel> UpdateBooking(UpdateBookingViewModel bookingUpdate);
        Task<BookingViewModel> CreateBooking(CreateBookingRequestModel bookingCreate);
        Task<BookingViewModel> GetById(int idTmp);
        Task<bool> DeleteBooking(int idTmp);
        Task<List<BookingViewModel>> GetAllBooking();

    }
    public class BookingService : IBookingService
    {

        private readonly BE_SWP391_OnDemandTutorDbContext _context;

        public BookingService(BE_SWP391_OnDemandTutorDbContext context)
        {
            _context = context;
        }
        public async Task<BookingViewModel> CreateBooking(CreateBookingRequestModel bookingCreate)
        {
            var booking = new Booking
            {
                CreateDate = bookingCreate.CreateDate,
                Description = bookingCreate.Description,
                Status = bookingCreate.Status,
                Address = bookingCreate.Address,
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return new BookingViewModel
            {
                Id = booking.Id,
                scheduleId = booking.ScheduleId,
                UserId = booking.UserId,
                createDate = booking.CreateDate,
                description = booking.Description,
                Address = booking.Address,

            };

                        /*var bookingViewModel = booking.Adapt<BookingViewModel>();
            return bookingViewModel;*/
        }

        public async Task<bool> DeleteBooking(int idTmp)
        {
            var delete = await _context.Bookings.FindAsync(idTmp);
            if (delete == null)
            {
                return false;
            }

            _context.Bookings.Remove(delete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<BookingViewModel>> GetAllBooking()
        {
            var booking = await _context.Bookings.ToListAsync();
            return booking.Select(booking => new BookingViewModel
            {
                Id = booking.Id,
                scheduleId = booking.ScheduleId,
                UserId = booking.UserId,
                createDate = booking.CreateDate,
                description = booking.Description,
                Address = booking.Address,


            }).ToList();
        }


        public async Task<BookingViewModel> GetById(int idTmp)
        {
            var booking = await _context.Bookings.FindAsync(idTmp);
            if (booking == null)
            {
                return null;
            }

            return new BookingViewModel
            {
                Id = booking.Id,
                scheduleId = booking.ScheduleId,
                UserId = booking.UserId,
                createDate = booking.CreateDate,
                description = booking.Description,
                Address = booking.Address,
            };
        }

        public async Task<BookingViewModel> UpdateBooking(UpdateBookingViewModel bookingUpdate)
        {
            var update = await _context.Bookings.FindAsync(bookingUpdate.Id);
            if (update == null)
            {
                return null;
            }
            update.CreateDate = bookingUpdate.CreateDate;
            update.Description = bookingUpdate.Description;
            update.Address = bookingUpdate.Address;


            await _context.SaveChangesAsync();

            return new BookingViewModel
            {
                Id = update.Id,
                scheduleId = update.ScheduleId,
                UserId = update.UserId,
                createDate = update.CreateDate,
                description = update.Description,
                Address = update.Address,
            };

        }
    }
    }
