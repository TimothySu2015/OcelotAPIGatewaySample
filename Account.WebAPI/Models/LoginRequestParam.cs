using System;
namespace Account.WebAPI.Models
{
    public class LoginRequestParam
    {
        public string ClientId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
