using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEcommerce.Application.Model
{
    public class AuthResponseDTO
    {
        public string Token { get; set; } = null!;
        public DateTime Expiration { get; set; }
    }
}
