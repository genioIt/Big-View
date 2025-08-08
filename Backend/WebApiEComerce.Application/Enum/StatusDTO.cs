using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEcommerce.Application.Enum
{
    public enum StatusDTO
    {
        Pending = 1,
        Confirmed = 2,
        Processing = 3,
        Shipped = 4,
        Delivered = 5,
        Cancelled = 6
    }
}
