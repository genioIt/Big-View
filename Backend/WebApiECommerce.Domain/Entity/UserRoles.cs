using System;
using System.Collections.Generic;
using System.Text;
using WebApiEcommerce.Domain.Common;
using WebApiEcommerce.Domain.Interface;

namespace WebApiEcommerce.Domain.Entity
{
    public class UserRoles : BaseEntity 
    {
        public int Id { get; set; }
        public int IdUsers { get; set; }
        public int IdRoles { get; set; }

        public Roles Roles { get; set; }
        public Users Users { get; set; }
    }
}
