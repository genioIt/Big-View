using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEcommerce.Application.Entity
{
    public class UsersDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

    }
}
