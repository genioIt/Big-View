using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiEcommerce.Domain.Common
{
    public class RolNotFoundException : EntityNotFoundException
    {
        public RolNotFoundException(int rolId)
           : base("Producto", rolId)
        {
        }

        public RolNotFoundException(string rolName)
            : base("Producto", "nombre", rolName)
        {
        }
    }
    public class RolNotActiveException : BusinessRuleException
    {
        public RolNotActiveException(string rolName)
            : base($"El rol '{rolName}' no está activo.", "PRODUCT_NOT_ACTIVE", rolName)
        {
        }
    }
}
