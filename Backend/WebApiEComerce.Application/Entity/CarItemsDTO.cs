using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEcommerce.Application.Entity
{
    public class CartItemsDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
