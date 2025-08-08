using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApiEcommerce.Application.App;
using WebApiEcommerce.Application.Entity;
using WebApiEcommerce.Application.Interface;
using WebApiEcommerce.Application.Model;
using WebApiEcommerce.Domain.Common;
using WebApiEcommerce.Domain.Entity;

namespace WebApiECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartApplication _cartApplication;

        public CartController(ICartApplication cartApplication)
        { 
            _cartApplication = cartApplication;
        }
        [HttpPost("AddItemsCart")]
        public async Task<IActionResult> AddItemsCart([FromBody] CartItemsDTO CartItemsDTO) 
        {
            var result = await _cartApplication.AddAsync(CartItemsDTO);
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

        [HttpPost("ActiveProductCart")]
        public async Task<IActionResult> ActiveProductCart(ActiveProdCartDTO activeProdCarDto)
        {
            var result = await _cartApplication.ActiveProductCart(activeProdCarDto);

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

        [HttpGet("GetByUserIdAsync")]
        public async Task<IActionResult> GetByUserIdAsync(int userId)
        {
            var result = await _cartApplication.GetByUserIdAsync(userId);
            if (result.Success)
                return Ok(result.Response);

            return result.Tipo switch
            {
                "ValidationError" => BadRequest(result),
                "BusinessError" => Conflict(result),
                "NotFound" => NotFound(result),
                _ => StatusCode(500, result)
            };
        }

        [HttpPut("RemoveItem")]
        public async Task<IActionResult> RemoveItemAsync([FromBody] RemoveItemsDTO removeItemsDTO)
        {
            var result = await _cartApplication.RemoveItemAsync(removeItemsDTO);
            if (result.Success)
                return Ok(result.Response);

            return result.Tipo switch
            {
                "ValidationError" => BadRequest(result),
                "BusinessError" => Conflict(result),
                "NotFound" => NotFound(result),
                _ => StatusCode(500, result)
            };
        }

        [HttpGet("GetCartProduct/{userId}")]
        public async Task<IActionResult> GetCartProductAsync(int userId)
        {
            var result = await _cartApplication.GetCartProductAsync(userId);
            if (result.Success)
                return Ok(result.Response);

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
