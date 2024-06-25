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
        private IUserService _userService;
        public BookingController(IBookingService bookingService, IUserService userService)
        {
            _bookingService = bookingService;
            _userService = userService;
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
        [HttpGet("{bookingId:int}")]
        public async Task<ActionResult<BookingViewModel>> GetById(int bookingId)
        {
            var booking = await _bookingService.GetById(bookingId);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }
        [MapToApiVersion("1")]
        [HttpGet("detail/{bookingId:int}")]
        public async Task<ActionResult<BookingDetailViewModel>> GetDetailByIdAsync(int bookingId)
        {
            var booking = await _bookingService.GetDetailById(bookingId);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        [MapToApiVersion("1")]
        [HttpGet("tutor/{tutorId:int}")]
        public async Task<ActionResult<BookingViewModel>> GetBookingByTutorId(int tutorId)
        {
            var user = await _userService.GetById(tutorId);
            if (user == null)
            {
                return NotFound("Tutor not found");
            }
            var bookings = await _bookingService.GetBookingByTutorId(tutorId);
            return Ok(bookings);
        }

        [MapToApiVersion("1")]
        [HttpGet("student/{studentId:int}")]
        public async Task<ActionResult<BookingViewModel>> GetBookingByStudentId(int studentId)
        {
            var user = await _userService.GetById(studentId);
            if (user == null)
            {
                return NotFound("Student not found");
            }
            var bookings = await _bookingService.GetBookingByStudentId(studentId);
            return Ok(bookings);
        }
        [MapToApiVersion("1")]
        [HttpPost]
        public async Task<ActionResult<BookingViewModel>> CreateBooking(CreateBookingRequestModel bookingCreate)
        {
            try
            {
                var createBooking = await _bookingService.CreateBooking(bookingCreate);
                if (createBooking != null)
                {
                    return CreatedAtAction(nameof(GetById), new { bookingId = createBooking.BookingId }, createBooking);
                }
                return BadRequest("Failed to create Booking.");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [MapToApiVersion("1")]
        [HttpPut("{bookingId:int}")]
        public async Task<ActionResult<BookingViewModel>> UpdateBooking(int bookingId, UpdateBookingViewModel updateModel)
        {
            var updateBooking = await _bookingService.UpdateBooking(bookingId, updateModel);
            if (updateBooking == null)
            {
                return NotFound();
            }

            return Ok(updateBooking);
        }

        [MapToApiVersion("1")]
        [HttpPut("status/{bookingId:int}")]
        public async Task<ActionResult<BookingViewModel>> UpdateBookingStatus(int bookingId, [FromQuery] string status)
        {
            var updateBooking = await _bookingService.UpdateBookingStatus(bookingId, status);
            if (updateBooking == null)
            {
                return NotFound();
            }

            return Ok(updateBooking);
        }

        [MapToApiVersion("1")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBooking(int bookingId)
        {
            var delete = await _bookingService.DeleteBooking(bookingId);
            if (!delete)
            {
                return NotFound();
            }

            return Ok(new { Message = $"Booking with ID '{bookingId}' deleted successfully." });
        }
    }
}
