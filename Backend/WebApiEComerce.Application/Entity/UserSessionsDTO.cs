using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEcommerce.Application.Entity
{
    public class UserSessionsDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SessiomToken { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string IPAddress { get; set; }
        public string UserAgent { get; set; }

    }
}
