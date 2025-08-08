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
    public class OrderItemsRepository : GenericRepository<OrderItems>, IOrderItemsRepository
    {
        public OrderItemsRepository(ECommerceBDContext context) : base(context)
        {
        }

        public async Task<IEnumerable<OrderItems>> GetByOrderIdAsync(int orderId)
        {
            // Verificar que la orden existe
            var orderExists = await _context.Orders.AnyAsync(o => o.Id == orderId);
            if (!orderExists)
                throw new OrderNotFoundException(orderId);

            var orderItems = await _dbSet
                .Where(oi => oi.OrderId == orderId)
                .Include(oi => oi.Products)
                .ToListAsync();

            if (!orderItems.Any())
                throw new EmptyOrderException();

            return orderItems;
        }

        public async Task<IEnumerable<OrderItems>> GetByProductIdAsync(int productId)
        {
            // Verificar que el producto existe
            var productExists = await _context.Products.AnyAsync(p => p.Id == productId);
            if (!productExists)
                throw new ProductNotFoundException(productId);

            return await _dbSet
                .Where(oi => oi.ProductId == productId)
                .Include(oi => oi.Orders)
                .ToListAsync();
        }

        //public async Task<bool> DeleteByOrderIdAsync(int orderId)
        //{
        //    // Verificar que la orden existe
        //    var order = await _context.Orders.FindAsync(orderId);
        //    if (order == null)
        //        throw new OrderNotFoundException(orderId);

        //    // Verificar que la orden no esté completada
        //    if (order.Status == WebApiEcommerce.Domain.Enum.Status.Completed)
        //        throw new OrderAlreadyCompletedException(orderId);

        //    var orderItems = await _dbSet
        //        .Where(oi => oi.OrderId == orderId)
        //        .ToListAsync();

        //    if (!orderItems.Any())
        //        throw new EmptyOrderException();

        //    _dbSet.RemoveRange(orderItems);
        //    await _context.SaveChangesAsync();
        //    return true;
        //}

        public override async Task<OrderItems> AddAsync(OrderItems entity)
        {
            if (entity.Quantity <= 0)
                throw new InvalidQuantityException(entity.Quantity);

            // Verificar que la orden existe
            var orderExists = await _context.Orders.AnyAsync(o => o.Id == entity.OrderId);
            if (!orderExists)
                throw new OrderNotFoundException(entity.OrderId);

            // Verificar que el producto existe y tiene stock suficiente
            var product = await _context.Products.FindAsync(entity.ProductId);
            if (product == null)
                throw new ProductNotFoundException(entity.ProductId);

            if (product.Stock < entity.Quantity)
                throw new InsufficientStockException(product.Name, entity.Quantity, product.Stock);

            if (!product.IsActive)
                throw new ProductNotActiveException(product.Name);

            return await base.AddAsync(entity);
        }

        //public override async Task<OrderItems> UpdateAsync(OrderItems entity)
        //{
        //    if (entity.Quantity <= 0)
        //        throw new InvalidQuantityException(entity.Quantity);

        //    // Verificar que la orden no esté completada
        //    var order = await _context.Orders.FindAsync(entity.OrderId);
        //    if (order != null && order.Status == WebApiEcommerce.Domain.Enum.Status.Completed)
        //        throw new OrderAlreadyCompletedException(entity.OrderId);

        //    // Verificar stock del producto
        //    var product = await _context.Products.FindAsync(entity.ProductId);
        //    if (product != null && product.Stock < entity.Quantity)
        //        throw new InsufficientStockException(product.Name, entity.Quantity, product.Stock);

        //    return await base.UpdateAsync(entity);
        //}

        public Task<bool> DeleteByOrderIdAsync(int orderId)
        {
            throw new System.NotImplementedException();
        }
    }
}