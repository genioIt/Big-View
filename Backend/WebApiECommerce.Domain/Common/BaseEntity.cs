using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEcommerce.Domain.Common
{
    public abstract class BaseEntity
    {
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }

        protected BaseEntity()
        {
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
        }
        public void SetUpdatedAt()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }

}
