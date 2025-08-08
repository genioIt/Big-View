using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiEcommerce.Domain.Entity;
using WebApiEcommerce.Domain.Model;

namespace WebApiEcommerce.Domain.Interface
{
    public interface ICartItemsRepository : IGenericRepository<CartItems>
    {
        Task<IEnumerable<CartItems>> GetByUserIdAsync(int userId);
        Task<CartItems> GetByUserAndProductAsync(int userId, int productId);
        Task<bool> DeleteByUserIdAsync(int userId);
        Task<decimal> GetCartTotalAsync(int userId);
        Task<bool> ActiveProductCart(int userId,int ProductId,bool Active);
        Task<CartItems> RemoveItemAsync(int idUser, int iditem);
        Task<IEnumerable<CartProducts>> GetCartProductAsync(int userId);


    }
}