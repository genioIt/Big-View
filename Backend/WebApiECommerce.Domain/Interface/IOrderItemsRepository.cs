using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiEcommerce.Domain.Entity;

namespace WebApiEcommerce.Domain.Interface
{
    public interface IOrderItemsRepository : IGenericRepository<OrderItems>
    {
        Task<IEnumerable<OrderItems>> GetByOrderIdAsync(int orderId);
        Task<IEnumerable<OrderItems>> GetByProductIdAsync(int productId);
        Task<bool> DeleteByOrderIdAsync(int orderId);
    }
}