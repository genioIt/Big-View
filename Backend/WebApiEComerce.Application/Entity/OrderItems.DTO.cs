using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEcommerce.Application.Entity
{
    public class OrderItemsDTO
    {
		public int Id { get; set; }
		public int OrderId { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public decimal UniyPrice { get; set; }
		public decimal TotalPrice { get; set; }
	}
}
