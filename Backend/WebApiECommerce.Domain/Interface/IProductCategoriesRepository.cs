using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiEcommerce.Domain.Entity;

namespace WebApiEcommerce.Domain.Interface
{
    public interface IProductCategoriesRepository : IGenericRepository<ProductCategories>
    {
        Task<ProductCategories> GetByNameAsync(string name);
        Task<IEnumerable<ProductCategories>> GetActiveAsync();
        Task<bool> NameExistsAsync(string name);
    }
}