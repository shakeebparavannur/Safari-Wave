using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Safari_Wave.Models;
using Safari_Wave.Models.DTOs.Booking;
using Safari_Wave.Repository.Interface;

namespace Safari_Wave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingSevice _bookingSevice;
        public BookingController(IBookingSevice bookingSevice)
        {
            _bookingSevice = bookingSevice;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllBooking()
        {
            var bookings = await _bookingSevice.GetBookings();
            if (bookings == null)
            {
                return NotFound();
            }
            return Ok(bookings);
        }
        [HttpPost("BookPackage")]
        [Authorize]
       // [Route("BookPackage")]
        public async Task<ActionResult> CreateBooking(CreateBookingDTO bookingData)
        {
            var currentUser = HttpContext.User.Identity.Name;

            var booking = await _bookingSevice.BookingPackage(currentUser, bookingData);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }
        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetBookingById(int id)
        {
            try
            {
                var booking = await _bookingSevice.GetBookingPackageById(id);
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet]
        [Route("user")]
        public async Task<ActionResult> GetBookings() 
        {
            try
            {
                var user = HttpContext.User.Identity.Name;
                var bookings = await _bookingSevice.GetBookingByUser(user);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "admin")]
        [HttpPut]
        [Route("statusUpdate")]
        public async Task <ActionResult> UpdateStatusByAdmin(int id , BookingUpdateDTO bookingUpdate)
        {
            try
            {
                var cancelBooking = await _bookingSevice.BookingStatusUpdate(id, bookingUpdate);
                return Ok(cancelBooking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPut]
        [Route("CancelOrder")]
        public async Task<ActionResult> CancelYourOrder(int id)
        {
            var user = HttpContext.User.Identity.Name;
            try
            {
                var cancelBooking = await _bookingSevice.CancelBooking(user, id);
                return Ok(cancelBooking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
