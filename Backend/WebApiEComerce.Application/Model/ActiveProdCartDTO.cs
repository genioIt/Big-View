using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEcommerce.Application.Model
{
    public class ActiveProdCartDTO
    {
        public int userId { get; set; } 
        public int ProductId { get; set; }
        public bool Active { get; set; }
    }
}   
