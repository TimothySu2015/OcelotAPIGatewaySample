using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Account.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Account.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        public AccountController()
        {

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] LoginRequestParam loginRequestParam)
        {
            string result = string.Empty;

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("client_id", loginRequestParam.ClientId);
            data.Add("client_secret", "secret");
            data.Add("grant_type", "password");
            data.Add("username", loginRequestParam.UserName);
            data.Add("password", loginRequestParam.Password);
         //   data.Add("scope", "PaymentService");

            using (var handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

                using (HttpClient http = new HttpClient(handler))
                {
                    using (var content = new FormUrlEncodedContent(data))
                    {
                        var msg = await http.PostAsync("http://192.168.10.41:6003/connect/token", content);
                        if (!msg.IsSuccessStatusCode)
                        {
                            return StatusCode(Convert.ToInt32(msg.StatusCode));
                        }

                        result = await msg.Content.ReadAsStringAsync();
                    }
                }
            

            }




            return Content(result,"application/json");
        }


        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }


}
