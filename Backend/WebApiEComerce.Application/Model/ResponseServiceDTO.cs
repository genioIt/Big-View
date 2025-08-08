using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEcommerce.Application.Model
{
    public class ResponseServiceDTO
    {
        public string Message { get; set; }
        public string Tipo { get; set; }
        public bool Success { get; set; }

        public object Response { get; set; }
    }
}
