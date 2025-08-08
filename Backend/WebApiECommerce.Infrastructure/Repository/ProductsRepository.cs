using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEcommerce.Domain.Entity;
using WebApiEcommerce.Domain.Interface;
using WebApiEcommerce.Domain.Common;
using WebApiEcommerce.Infrastructure.Persistence;

namespace WebApiECommerce.Infrastructure.Repository
{
    public class ProductsRepository : GenericRepository<Products>, IProductsRepository
    {
        public ProductsRepository(ECommerceBDContext context) : base(context)
        {
        }

        public override async Task<Products> GetByIdAsync(int id)
        {
            var product = await base.GetByIdAsync(id);
            if (product == null)
                throw new ProductNotFoundException(id);
            return product;
        }

        public async Task<IEnumerable<Products>> GetByCategoryAsync(int idcategory)
        {
            return await _dbSet
                .Where(p => p.IdCategory == idcategory)
                .ToListAsync();
        }

        public async Task<IEnumerable<Products>> GetActiveProductsAsync()
        {
            return await _dbSet
                .Where(p => p.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<Products>> SearchByNameAsync(string name)
        {
            var products = await _dbSet
                .Where(p => p.Name.Contains(name))
                .ToListAsync();
            
            if (!products.Any())
                throw new ProductNotFoundException(name);
            
            return products;
        }

        public async Task<IEnumerable<Products>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await _dbSet
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .ToListAsync();
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var product = await base.GetByIdAsync(id);
            if (product == null)
                throw new ProductNotFoundException(id);
            
            if (!product.IsActive)
                throw new ProductNotActiveException(product.Name);
            
            return await base.DeleteAsync(id);
        }

        public async Task<IEnumerable<Products>> GetByCategoryActiveAsync(int idcategory)
        {
            return await _dbSet
               .Where(p => p.IdCategory == idcategory && p.IsActive)
               .Include(ci => ci.ProductCategories)
               .ToListAsync();
        }
    }
}