using System;
using System.Collections.Generic;
using System.Text;
using WebApiEcommerce.Domain.Common;
using WebApiEcommerce.Domain.Entity;

namespace WebApiEcommerce.Domain.Entity
{
    public class Products : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int IdCategory { get; private set; }
        public string ImageUrl { get; private set; }
        public double Rating { get; private set; }
        public int Stock { get; private set; }


        public ProductCategories ProductCategories { get; private set; }
        public ICollection<OrderItems> OrderItems { get; set; }
        public ICollection<CartItems> CartItems { get; set; }
    }
}
