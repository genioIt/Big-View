using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEcommerce.Application.Model
{
    public class CartProductsDTO
    {
        public string ProductId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool isActive { get; set; }
    }
}
