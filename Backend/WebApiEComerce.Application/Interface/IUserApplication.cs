using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiEcommerce.Application.Entity;
using WebApiEcommerce.Application.Model;

namespace WebApiEcommerce.Application.Interface
{
    public interface IUserApplication
    {
        Task<ResponseServiceDTO> CreateUserAsync(UsersDTO userDto);
        Task<ResponseServiceDTO> UpdateUserAsync(UsersDTO userDto);
        Task<ResponseServiceDTO> DeleteUserAsync(int userId);
        Task<UsersDTO> GetUserByIdAsync(int userId);
        Task<UsersDTO> GetUserByEmailAsync(string email);
        Task<IEnumerable<UsersDTO>> GetAllUsersAsync();
        Task<ResponseServiceDTO> ValidateUserCredentialsAsync(string email, string password);
        Task<bool> EmailExistsAsync(string email);
    }
}
