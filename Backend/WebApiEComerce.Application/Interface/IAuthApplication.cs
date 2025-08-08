using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiEcommerce.Application.Model;

namespace WebApiEcommerce.Application.Interface
{
    public interface IAuthApplication
    {
        Task<AuthResponseDTO> Login(string email, string password);
    }
}
