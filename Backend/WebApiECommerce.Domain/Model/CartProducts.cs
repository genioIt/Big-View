using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEcommerce.Domain.Model
{
    public class CartProducts
    {
        public int ProductId { get; set; }   
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool isActive { get; set; }
    }
}
