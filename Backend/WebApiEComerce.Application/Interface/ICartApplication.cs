using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiEcommerce.Application.Entity;
using WebApiEcommerce.Application.Model;
using WebApiEcommerce.Domain.Entity;
using WebApiEcommerce.Domain.Model;

namespace WebApiEcommerce.Application.Interface
{
    public interface ICartApplication
    {
        Task<ResponseServiceDTO> GetByUserIdAsync(int userId);
        Task<ResponseServiceDTO> AddAsync(CartItemsDTO entity);
        Task<ResponseServiceDTO> ActiveProductCart(ActiveProdCartDTO ActiveProdCartDto);
        Task<ResponseServiceDTO> RemoveItemAsync(RemoveItemsDTO entity);
        Task<ResponseServiceDTO> GetCartProductAsync(int userId);
    }
}
