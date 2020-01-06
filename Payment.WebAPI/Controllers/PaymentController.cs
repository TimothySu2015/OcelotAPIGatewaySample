using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Payment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class PaymentController : Controller
    {
        // GET: api/values
        [HttpGet("GetPayment")]
        public string Get()
        {
            return "Payment Service";
        }
    }
}
