using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEcommerce.Application.Model
{
    public class LoginRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
