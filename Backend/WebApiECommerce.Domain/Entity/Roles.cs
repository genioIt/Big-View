using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEcommerce.Domain.Entity
{
    public class Roles
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserRoles> userRoles { get; set; }
    }
}
