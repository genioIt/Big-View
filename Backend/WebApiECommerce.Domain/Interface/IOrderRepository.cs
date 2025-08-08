using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiEcommerce.Domain.Entity;
using WebApiEcommerce.Domain.Enum;

namespace WebApiEcommerce.Domain.Interface
{
    public interface IOrderRepository : IGenericRepository<Orders>
    {
        Task<IEnumerable<Orders>> GetByUserIdAsync(int userId);
        Task<IEnumerable<Orders>> GetByStatusAsync(Status status);
        Task<IEnumerable<Orders>> GetByPaymentMethodAsync(PaymentMethod paymentMethod);
        Task<Orders> GetOrderWithItemsAsync(int orderId);
    }
}