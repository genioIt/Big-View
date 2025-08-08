using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApiEcommerce.Domain.Interface
{
    public interface IJwtProvider
    {
        string GenerateToken(string email, IEnumerable<string> roles);
    }
}
