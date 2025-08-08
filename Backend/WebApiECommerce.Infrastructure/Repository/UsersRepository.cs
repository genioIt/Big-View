using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApiEcommerce.Domain.Entity;
using WebApiEcommerce.Domain.Interface;
using WebApiEcommerce.Domain.Common;
using WebApiEcommerce.Infrastructure.Persistence;

namespace WebApiECommerce.Infrastructure.Repository
{
    public class UsersRepository : GenericRepository<Users>,IUsersRepository
    {
        public UsersRepository(ECommerceBDContext context) : base(context)
        {
        }

        public override async Task<Users> GetByIdAsync(int id)
        {
            var user = await base.GetByIdAsync(id);
            if (user == null)
                throw new UserNotFoundException(id);
            return user;
        }

        public async Task<Users> GetByEmailAsync(string email)
        {
            var user = await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                throw new UserNotFoundException(email);
            return user;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _dbSet.AnyAsync(u => u.Email == email);
        }

        public override async Task<Users> AddAsync(Users entity)
        {
            if (await EmailExistsAsync(entity.Email))
                throw new UserAlreadyExistsException(entity.Email);
            
            return await base.AddAsync(entity);
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            if (!await ExistsAsync(id))
                throw new UserNotFoundException(id);
            
            return await base.DeleteAsync(id);
        }

        public async Task<Users> GetByUsernameAndPassword(string email, string passwordHash)
        {
            var user = await _dbSet.FirstOrDefaultAsync(u => u.Email == email &&  u.PasswordHash== passwordHash);
            if (user == null)
                throw new UserNotFoundException(email);
            return user;
        }
    }
}