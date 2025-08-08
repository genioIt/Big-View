using System;
using System.Collections.Generic;
using System.Text;
using WebApiEcommerce.Domain.Common;
using WebApiEcommerce.Domain.Entity;

namespace WebApiEcommerce.Domain.Entity
{
    public class CartItems : BaseEntity 
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Users Users { get; set; }
        public Products Products { get; set; }
    }
}
