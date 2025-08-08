using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiEcommerce.Application.Entity;
using WebApiEcommerce.Application.Model;

namespace WebApiEcommerce.Application.Interface
{
    public interface IUserRolesApplication
    {
        Task<ResponseServiceDTO> CreateUserRolesAsync(UserRolesDTO entity);
    }
}
