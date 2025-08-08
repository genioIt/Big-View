using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEcommerce.Domain.Entity;
using WebApiEcommerce.Domain.Enum;
using WebApiEcommerce.Domain.Interface;
using WebApiEcommerce.Domain.Common;
using WebApiEcommerce.Infrastructure.Persistence;

namespace WebApiECommerce.Infrastructure.Repository
{
    public class OrderRepository : GenericRepository<Orders>, IOrderRepository
    {
        public OrderRepository(ECommerceBDContext context) : base(context)
        {
        }

        public override async Task<Orders> GetByIdAsync(int id)
        {
            var order = await base.GetByIdAsync(id);
            if (order == null)
                throw new OrderNotFoundException(id);
            return order;
        }

        public async Task<IEnumerable<Orders>> GetByUserIdAsync(int userId)
        {
            return await _dbSet
                .Where(o => o.UserId == userId)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Products)
                .ToListAsync();
        }

        //public async Task<IEnumerable<Orders>> GetByStatusAsync(Status status)
        //{
        //    return await _dbSet
        //        .Where(o => o.Status == status)
        //        .Include(o => o.OrderItems)
        //        .ToListAsync();
        //}

        //public async Task<IEnumerable<Orders>> GetByPaymentMethodAsync(PaymentMethod paymentMethod)
        //{
        //    return await _dbSet
        //        .Where(o => o.PaymentMethod == paymentMethod)
        //        .Include(o => o.OrderItems)
        //        .ToListAsync();
        //}

        public async Task<Orders> GetOrderWithItemsAsync(int orderId)
        {
            var order = await _dbSet
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Products)
                .Include(o => o.Users)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
                throw new OrderNotFoundException(orderId);

            return order;
        }

        public override async Task<Orders> AddAsync(Orders entity)
        {
            if (entity.TotalAmount <= 0)
                throw new InvalidOrderAmountException(entity.TotalAmount);

            return await base.AddAsync(entity);
        }

        //public override async Task<Orders> UpdateAsync(Orders entity)
        //{
        //    var existingOrder = await base.GetByIdAsync(entity.Id);
        //    if (existingOrder == null)
        //        throw new OrderNotFoundException(entity.Id);

        //    if (existingOrder.Status == Status.Completed)
        //        throw new OrderAlreadyCompletedException(entity.Id);

        //    return await base.UpdateAsync(entity);
        //}

        public override async Task<bool> DeleteAsync(int id)
        {
            var order = await base.GetByIdAsync(id);
            if (order == null)
                throw new OrderNotFoundException(id);

            //if (order.Status == Status.Completed || order.Status == Status.Shipped)
            //    throw new OrderCannotBeCancelledException(id, order.Status);

            return await base.DeleteAsync(id);
        }

        public Task<IEnumerable<Orders>> GetByPaymentMethodAsync(PaymentMethod paymentMethod)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Orders>> GetByStatusAsync(Status status)
        {
            throw new System.NotImplementedException();
        }
    }
}