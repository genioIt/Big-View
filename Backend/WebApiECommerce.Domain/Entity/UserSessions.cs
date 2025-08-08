using System;
using System.Collections.Generic;
using System.Text;
using WebApiEcommerce.Domain.Common;

namespace WebApiEcommerce.Domain.Entity
{
    public class UserSessions : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SessiomToken { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string IPAddress { get; set; }
        public string UserAgent { get; set; }


        public Users Users { get; set; }

    }
}
