using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiEcommerce.Domain.Entity;

namespace WebApiEcommerce.Domain.Interface
{
    public interface IUsersRepository : IGenericRepository<Users>
    {
        Task<Users> GetByEmailAsync(string email);
        Task<bool> EmailExistsAsync(string email);
        Task<Users> GetByUsernameAndPassword(string username, string password);
    }
}