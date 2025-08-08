using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiEcommerce.Domain.Entity;

namespace WebApiEcommerce.Domain.Interface
{
    public interface IUserSessionsRepository : IGenericRepository<UserSessions>
    {
        Task<IEnumerable<UserSessions>> GetByUserIdAsync(int userId);
        Task<UserSessions> GetByTokenAsync(string token);
        Task<bool> DeleteByUserIdAsync(int userId);
        Task<bool> DeleteExpiredSessionsAsync();
    }
}