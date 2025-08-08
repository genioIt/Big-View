using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiEcommerce.Application.Entity;

namespace WebApiEcommerce.Application.Interface
{
    public interface IProductApplication
    {
        Task<IEnumerable<ProductsDTO>> GetByCategoryActiveAsync(int idcategory);
    }
}
