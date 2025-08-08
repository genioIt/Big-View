using System;
using System.Collections.Generic;
using System.Text;
using WebApiEcommerce.Domain.Common;

namespace WebApiEcommerce.Domain.Entity
{
    public class Users : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<UserSessions> UserSessions { get; set; }
        public ICollection<CartItems> CartItems { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<UserRoles> userRoles { get; set; }

    }
}
