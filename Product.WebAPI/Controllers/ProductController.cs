using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        // GET: api/values
        [HttpGet("GetProducts")]
        public string Get()
        {
            return "Products Service";
        }
    }
}
