using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiEcommerce.Application.Entity;
using WebApiEcommerce.Application.Interface;
using WebApiEcommerce.Application.Model;

namespace WebApiECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersApplication _OrdersApplication;

        public OrdersController(IOrdersApplication ordersApplication)
        {
            _OrdersApplication = ordersApplication;
        }

        [HttpPost("AddOrders")]
        public async Task<IActionResult> AddAsync([FromBody] OrdersDTO orders)
        { 
            var result= await _OrdersApplication.AddAsync(orders);
            if (result.Success)
                return Ok(result);

            return result.Tipo switch
            {
                "ValidationError" => BadRequest(result),
                "BusinessError" => Conflict(result),
                "NotFound" => NotFound(result),
                _ => StatusCode(500, result)
            };
        }
    }
}
