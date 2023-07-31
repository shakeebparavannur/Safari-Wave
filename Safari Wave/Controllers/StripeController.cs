using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Safari_Wave.Models;
using Safari_Wave.Models.Stripe;
using Safari_Wave.Repository.Interface;
using Stripe;
using System.Drawing.Printing;
using System.Net;

namespace Safari_Wave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        protected APIResponse response;
        private readonly IConfiguration configuration;
        private readonly SafariWaveContext context;
        public StripeController(IConfiguration configuration,SafariWaveContext context)
        {
            this.configuration = configuration;
            this.context = context;
            response = new();
        }
        [HttpPost]
        public async Task <ActionResult<APIResponse>> MakePayment(int bookingId)
        {
            var booking = await context.Bookings.FirstOrDefaultAsync(b=>b.BookingId ==  bookingId);
            if (booking == null || booking.Payment == "success")
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                return BadRequest(response);
            }
            StripeConfiguration.ApiKey = configuration["Stripe:SecretKey"];
            decimal totalamount = booking.Amount;

            PaymentIntentCreateOptions options = new ()
            {
                Amount = (long?)totalamount,
                Currency = "inr",
                
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = true,
                },
            };
            PaymentIntentService service = new();
            PaymentIntent result = service.Create(options);
            booking.StripePaymentIntentId = result.Id;
            booking.ClientSecret = result.ClientSecret;
            response.Result = booking;
            response.StatusCode = HttpStatusCode.OK;
            return Ok(response);
        }
    }
}
