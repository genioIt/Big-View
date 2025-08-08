using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiEcommerce.Domain.Entity;

namespace WebApiEcommerce.Domain.Interface
{
    public interface IProductsRepository : IGenericRepository<Products>
    {
        Task<IEnumerable<Products>> GetByCategoryAsync(int idcategory);
        Task<IEnumerable<Products>> GetByCategoryActiveAsync(int idcategory);
        Task<IEnumerable<Products>> GetActiveProductsAsync();
        Task<IEnumerable<Products>> SearchByNameAsync(string name);
        Task<IEnumerable<Products>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice);
    }
}