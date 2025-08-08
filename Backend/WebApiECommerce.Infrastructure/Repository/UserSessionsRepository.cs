using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEcommerce.Domain.Entity;
using WebApiEcommerce.Domain.Interface;
using WebApiEcommerce.Domain.Common;
using WebApiEcommerce.Infrastructure.Persistence;

namespace WebApiECommerce.Infrastructure.Repository
{
    public class UserSessionsRepository : GenericRepository<UserSessions>, IUserSessionsRepository
    {
        public UserSessionsRepository(ECommerceBDContext context) : base(context)
        {
        }

        public override async Task<UserSessions> GetByIdAsync(int id)
        {
            var session = await base.GetByIdAsync(id);
            if (session == null)
                throw new SessionNotFoundException(id);
            return session;
        }

        public async Task<IEnumerable<UserSessions>> GetByUserIdAsync(int userId)
        {
            return await _dbSet
                .Where(us => us.UserId == userId)
                .Include(us => us.Users)
                .ToListAsync();
        }

        public async Task<UserSessions> GetByTokenAsync(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new InvalidTokenException();

            var session = await _dbSet
                .Include(us => us.Users)
                .FirstOrDefaultAsync(us => us.SessiomToken == token);

            if (session == null)
                throw new SessionNotFoundException(token);

            // Verificar si la sesión ha expirado
            if (session.ExpiresAt < DateTime.UtcNow)
                throw new SessionExpiredException(token);

            return session;
        }

        public async Task<bool> DeleteByUserIdAsync(int userId)
        {
            var userSessions = await _dbSet
                .Where(us => us.UserId == userId)
                .ToListAsync();

            if (!userSessions.Any())
                return false;

            _dbSet.RemoveRange(userSessions);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteExpiredSessionsAsync()
        {
            var expiredSessions = await _dbSet
                .Where(us => us.ExpiresAt < DateTime.UtcNow)
                .ToListAsync();

            if (!expiredSessions.Any())
                return false;

            _dbSet.RemoveRange(expiredSessions);
            await _context.SaveChangesAsync();
            return true;
        }

        public override async Task<UserSessions> AddAsync(UserSessions entity)
        {
            if (string.IsNullOrEmpty(entity.SessiomToken))
                throw new InvalidTokenException();

            // Verificar que el usuario existe
            var userExists = await _context.Users.AnyAsync(u => u.Id == entity.UserId);
            if (!userExists)
                throw new UserNotFoundException(entity.UserId);

            return await base.AddAsync(entity);
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var session = await base.GetByIdAsync(id);
            if (session == null)
                throw new SessionNotFoundException(id);

            return await base.DeleteAsync(id);
        }
    }
}