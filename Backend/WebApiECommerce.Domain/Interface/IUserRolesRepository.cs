using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiEcommerce.Domain.Entity;

namespace WebApiEcommerce.Domain.Interface
{
    public interface IUserRolesRepository : IGenericRepository<UserRoles>
    {
       Task<IEnumerable<string>> GetRolesByIdUser(int IdUsers);
    }
}
