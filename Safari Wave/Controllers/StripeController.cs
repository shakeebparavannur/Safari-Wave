using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Safari_Wave.Models.Stripe;
using Safari_Wave.Repository.Interface;

namespace Safari_Wave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        private readonly IStripeAppService _stripeAppService;
        public StripeController(IStripeAppService stripeAppService)
        {
            _stripeAppService = stripeAppService;
        }
        [HttpPost("customer/add")]
        public async Task<ActionResult<StripeCustomer>> AddStripeCustomer([FromBody] AddStripeCustomer customer,CancellationToken ct)
        {
            StripeCustomer createdCustomer = await _stripeAppService.AddStripeCustomer(customer, ct);
            return Ok(createdCustomer);
        }
    }
}
