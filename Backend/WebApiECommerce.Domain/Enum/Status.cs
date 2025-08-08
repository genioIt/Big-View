using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEcommerce.Domain.Enum
{
    public enum Status
    {
        Pending = 1,
        Confirmed = 2,
        Processing = 3,
        Shipped = 4,
        Delivered = 5,
        Cancelled = 6,
        Completed=7
    }
}
