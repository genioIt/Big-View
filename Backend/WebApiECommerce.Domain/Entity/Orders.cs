using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WebApiEcommerce.Domain.Common;
using WebApiEcommerce.Domain.Enum;

namespace WebApiEcommerce.Domain.Entity
{
    public class Orders : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; }
        public string ShippingAddress { get;  set; }
        public string ShippingCity { get;  set; }
        public string ShippingZipCode{ get;  set; }
        public int PaymentMethod { get; set; }
        public int PaymentStatus { get; set; }
        public DateTime? CompletedAt { get; set; }

        public Users Users { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
