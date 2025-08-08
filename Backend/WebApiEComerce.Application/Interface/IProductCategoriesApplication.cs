using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiEcommerce.Application.Entity;
using WebApiEcommerce.Domain.Entity;

namespace WebApiEcommerce.Application.Interface
{
    public interface IProductCategoriesApplication
    {
        Task<IEnumerable<ProductCategoriesDTO>> GetActiveAsync();
    }
}
