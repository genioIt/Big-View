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
    public class ProductCategoriesRepository : GenericRepository<ProductCategories>, IProductCategoriesRepository
    {
        public ProductCategoriesRepository(ECommerceBDContext context) : base(context)
        {
        }

        public override async Task<ProductCategories> GetByIdAsync(int id)
        {
            var category = await base.GetByIdAsync(id);
            if (category == null)
                throw new CategoryNotFoundException(id);
            return category;
        }

        public async Task<ProductCategories> GetByNameAsync(string name)
        {
            var category = await _dbSet
                .FirstOrDefaultAsync(pc => pc.Name == name);
            
            if (category == null)
                throw new CategoryNotFoundException(name);
            
            return category;
        }

        public async Task<IEnumerable<ProductCategories>> GetActiveAsync()
        {
            return await _dbSet
                .Where(pc => pc.IsActive)
                .ToListAsync();
        }

        public async Task<bool> NameExistsAsync(string name)
        {
            return await _dbSet
                .AnyAsync(pc => pc.Name == name);
        }

        public override async Task<ProductCategories> AddAsync(ProductCategories entity)
        {
            if (await NameExistsAsync(entity.Name))
                throw new CategoryAlreadyExistsException(entity.Name);
            
            return await base.AddAsync(entity);
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var category = await base.GetByIdAsync(id);
            if (category == null)
                throw new CategoryNotFoundException(id);

            // Verificar si la categoría tiene productos asociados
            var hasProducts = await _context.Products
                .AnyAsync(p => p.IdCategory == category.Id);
            
            if (hasProducts)
                throw new CategoryHasProductsException(category.Name);

            return await base.DeleteAsync(id);
        }

    }
}