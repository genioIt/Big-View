using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiEcommerce.Application.Entity;
using WebApiEcommerce.Application.Model;
using WebApiEcommerce.Domain.Entity;

namespace WebApiEcommerce.Application.Interface
{
    public interface IOrdersApplication
    {
        Task<ResponseServiceDTO> AddAsync(OrdersDTO entity);
    }
}
