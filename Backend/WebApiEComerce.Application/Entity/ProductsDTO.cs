using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEcommerce.Application.Entity
{
    public class ProductsDTO
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int IdCategory { get; private set; }
        public string ImageUrl { get; private set; }
        public double Rating { get; private set; }
        public int Stock { get; private set; }
        public bool IsActive { get; private set; }

    }
}
