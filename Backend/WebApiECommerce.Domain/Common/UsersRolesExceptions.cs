using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEcommerce.Domain.Common
{
    public class UsersRolesByUserNotFoundException : EntityNotFoundException
    {
        public UsersRolesByUserNotFoundException(int idUsers)
          : base("UsuarioRoles", idUsers)
        {
        }

    }

    public class UsersRolesByRolNotFoundException : EntityNotFoundException
    {
        public UsersRolesByRolNotFoundException(int idRoles)
          : base("UsuarioRoles", idRoles)
        {
        }

    }
}
