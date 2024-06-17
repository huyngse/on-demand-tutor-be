using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Booking;
using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Feedback;
using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels.Booking;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BE_SWP391_OnDemandTutor.Presentation.Controllers
{

    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v1/bookings")]
    public class BookingController : ControllerBase
    {

        private IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }


        [MapToApiVersion("1")]
        [HttpPost]
        public async Task<ActionResult<BookingViewModel>> CreateBooking(CreateBookingRequestModel bookingCreate)
        {
            try
            {
                var createBooking = await _bookingService.CreateBooking(bookingCreate);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = createBooking.Id }, createBooking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [MapToApiVersion("1")]
        [HttpGet]
        public async Task<ActionResult<List<BookingViewModel>>> GetAll()
        {
            var booking = await _bookingService.GetAllBooking();
            if (booking == null)
            {
                return NotFound("");
            }
            return Ok(booking);
        }

        [MapToApiVersion("1")]
        [HttpGet("idTmp")]
        public async Task<ActionResult<BookingViewModel>> GetByIdAsync(int idTmp)
        {
            var booking = await _bookingService.GetById(idTmp);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteFeedbackAsync(int idTmp)
        {
            var delete = await _bookingService.DeleteBooking(idTmp);
            if (!delete)
            {
                return NotFound();
            }

            return Ok(new { Message = $"Booking with ID '{idTmp}' deleted successfully." });
        }

        [MapToApiVersion("1")]
        [HttpPut]
        public async Task<ActionResult<BookingViewModel>> UpdateBooking(int id, UpdateBookingViewModel bookingUpdate)
        {
            if (id != bookingUpdate.Id)
            {
                return BadRequest("ID in the request body does not match the route parameter.");
            }

            var updateBooking = await _bookingService.UpdateBooking(bookingUpdate);
            if (updateBooking == null)
            {
                return NotFound();
            }

            return Ok(updateBooking);
        }
    }

}
