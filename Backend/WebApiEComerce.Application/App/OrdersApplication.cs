using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiEcommerce.Application.Entity;
using WebApiEcommerce.Application.Interface;
using WebApiEcommerce.Application.Model;
using WebApiEcommerce.Domain.Common;
using WebApiEcommerce.Domain.Entity;
using WebApiEcommerce.Domain.Interface;

namespace WebApiEcommerce.Application.App
{
    public class OrdersApplication : IOrdersApplication
    {
        private readonly IOrderRepository _OrderRepository;
        private IMapper _mapper;

        public OrdersApplication(IOrderRepository orderRepository, IMapper mapper)
        {
            _OrderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<ResponseServiceDTO> AddAsync(OrdersDTO entity)
        {
            try
            {
                Orders ordersMap = _mapper.Map<OrdersDTO, Orders>(entity);
                Orders Orders = await _OrderRepository.AddAsync(ordersMap);

                return new ResponseServiceDTO
                {
                    Success = true,
                    Message = "Se ha agregado la orden del pedido",
                    Tipo = "Success"
                };
            }
            catch (InvalidOrderAmountException ex)
            {
                return new ResponseServiceDTO
                {
                    Success = true,
                    Message = ex.Message,
                    Tipo = "BusinessError"
                };
            }
            catch (Exception ex)
            {
                return new ResponseServiceDTO
                {
                    Success = true,
                    Message = ex.Message,
                    Tipo = "BusinessError"
                };
            }
        }
    }
}
