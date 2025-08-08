using System;
using System.Collections.Generic;
using System.Text;
using WebApiEcommerce.Domain.Common;

namespace WebApiEcommerce.Domain.Entity
{
    public class ProductCategories : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<OrderItems> OrderItems { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
