using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEcommerce.Domain.Entity;
using WebApiEcommerce.Domain.Interface;
using WebApiEcommerce.Domain.Common;
using WebApiEcommerce.Infrastructure.Persistence;
using System;
using WebApiEcommerce.Domain.Model;

namespace WebApiECommerce.Infrastructure.Repository
{
    public class CartItemsRepository : GenericRepository<CartItems>, ICartItemsRepository
    {
        public CartItemsRepository(ECommerceBDContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CartItems>> GetByUserIdAsync(int userId)
        {
            var cartItems = await _dbSet
                .Where(ci => ci.UserId == userId)
                .Include(ci => ci.Products)
                .ToListAsync();

            if (!cartItems.Any())
                throw new EmptyCartException(userId);

            return cartItems;
        }

        public async Task<CartItems> GetByUserAndProductAsync(int userId, int productId)
        {
            var cartItem = await _dbSet
                .Include(ci => ci.Products)
                .FirstOrDefaultAsync(ci => ci.UserId == userId && ci.ProductId == productId);
            return cartItem;
        }

        public async Task<bool> DeleteByUserIdAsync(int userId)
        {
            var cartItems = await _dbSet
                .Where(ci => ci.UserId == userId)
                .ToListAsync();

            if (!cartItems.Any())
                throw new EmptyCartException(userId);

            _dbSet.RemoveRange(cartItems);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<decimal> GetCartTotalAsync(int userId)
        {
            var cartItems = await _dbSet
                .Where(ci => ci.UserId == userId)
                .Include(ci => ci.Products)
                .ToListAsync();

            if (!cartItems.Any())
                throw new EmptyCartException(userId);

            return cartItems.Sum(ci => ci.Quantity * ci.Products.Price);
        }

        public override async Task<CartItems> AddAsync(CartItems entity)
        {
            if (entity.Quantity <= 0)
                throw new InvalidQuantityException(entity.Quantity);

            // Verificar si el producto tiene stock suficiente
            var product = await _context.Products.FindAsync(entity.ProductId);
            if (product == null)
                throw new ProductNotFoundException(entity.ProductId);

            if (product.Stock < entity.Quantity)
                throw new InsufficientStockException(product.Name, entity.Quantity, product.Stock);

            if (!product.IsActive)
                throw new ProductNotActiveException(product.Name);


            CartItems cartItems = await GetByUserAndProductAsync(entity.UserId, entity.ProductId);
            if (cartItems == null)
                return await base.AddAsync(entity);
            else
            {
                cartItems.Quantity += 1;
                cartItems.IsActive=true;
                cartItems.SetUpdatedAt();
                return await base.UpdateAsync(cartItems);
            }

        }

        public override async Task<CartItems> UpdateAsync(CartItems entity)
        {
            if (entity.Quantity <= 0)
                throw new InvalidQuantityException(entity.Quantity);

            var product = await _context.Products.FindAsync(entity.ProductId);
            if (product == null)
                throw new ProductNotFoundException(entity.ProductId);

            if (product.Stock < entity.Quantity)
                throw new InsufficientStockException(product.Name, entity.Quantity, product.Stock);

            return await base.UpdateAsync(entity);
        }

        public async Task<bool> ActiveProductCart(int userId, int ProductId, bool Active)
        {
            var cartItems = await _dbSet
               .Where(ci => ci.UserId == userId && ci.ProductId == ProductId)
               .Include(ci => ci.Products)
               .Include(ci => ci.Users)
               .FirstOrDefaultAsync();

            if (cartItems == null)
                throw new CartItemNotFoundException(userId, ProductId);

            cartItems.IsActive = Active;
            if (!Active)
                cartItems.Quantity = 0;
            cartItems.SetUpdatedAt();

            await base.UpdateAsync(cartItems);
            return true;
        }

        
        public async Task<CartItems> RemoveItemAsync(int idUser, int iditem)
        {
            var cartItems = await _dbSet
                .Where(ci => ci.UserId == idUser && ci.ProductId== iditem)
                .Include(ci => ci.Products)
                .FirstOrDefaultAsync();

            if (cartItems == null)
                throw new EmptyCartException(idUser);
            if(cartItems.Quantity>=1)
                cartItems.Quantity -= 1;

            cartItems.SetUpdatedAt();
            return await base.UpdateAsync(cartItems);
        }

        public async Task<IEnumerable<CartProducts>> GetCartProductAsync(int userId)
        {
            var result = await _dbSet
                 .Where(c => c.UserId == userId && c.IsActive && c.Quantity!=0)
                 .Include(c => c.Products)
                 .Select(c => new CartProducts
                 {
                    UserId = c.UserId,
                    ProductId = c.ProductId,
                    Name = c.Products.Name,
                    Price = c.Products.Price,
                    Description = c.Products.Description,
                    Quantity = c.Quantity,
                    isActive = c.IsActive
                 })
                 .ToListAsync();

            if (!result.Any())
                throw new EmptyCartException(userId);

            return result;
        }
    }       
}