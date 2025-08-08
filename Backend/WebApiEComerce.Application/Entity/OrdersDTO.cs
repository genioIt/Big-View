using System;
using System.Collections.Generic;
using System.Text;
using WebApiEcommerce.Application.Enum;

namespace WebApiEcommerce.Application.Entity
{
    public class OrdersDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; }
        public string ShippingAddress { get;  set; }
        public string ShippingCity { get;  set; }
        public string ShippingZipCode { get;  set; }
        public int PaymentMethod { get; set; }
        public int PaymentStatus { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
