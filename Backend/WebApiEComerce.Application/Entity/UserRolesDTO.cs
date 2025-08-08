using System;
using System.Collections.Generic;
using System.Text;
using WebApiEcommerce.Domain.Entity;

namespace WebApiEcommerce.Application.Entity
{
    public class UserRolesDTO
    {
        public int Id { get; set; }
        public int IdUsers { get; set; }
        public int IdRoles { get; set; }
    }
}
