using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiEcommerce.Domain.Common;
using WebApiEcommerce.Domain.Entity;
using WebApiEcommerce.Domain.Interface;
using WebApiEcommerce.Infrastructure.Persistence;
using WebApiECommerce.Infrastructure.Repository;

namespace WebApiEcommerce.Infrastructure.Repository
{
    public class UserRolesRepository : GenericRepository<UserRoles>, IUserRolesRepository
    {
        public UserRolesRepository(ECommerceBDContext context) : base(context) { }

        public async Task<IEnumerable<string>> GetRolesByIdUser(int IdUsers)
        {
            var usersRol = await _dbSet
               .Where(ur => ur.IdUsers == IdUsers)
               .Include(ur => ur.Users)
               .Include(ur => ur.Roles)
               .ToListAsync();

            if (!usersRol.Any())
                throw new UsersRolesByUserNotFoundException(IdUsers);
            else
                return usersRol.Select(ur=>ur.Roles.Name).ToList();

        }
    }
}
