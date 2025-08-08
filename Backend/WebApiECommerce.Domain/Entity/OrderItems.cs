using System;
using System.Collections.Generic;
using System.Text;
using WebApiEcommerce.Domain.Common;
using WebApiEcommerce.Domain.Entity;

namespace WebApiEcommerce.Domain.Entity
{
    public class OrderItems : BaseEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UniyPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public Orders Orders { get; set; }
        public Products Products { get; set; }
    }
}
