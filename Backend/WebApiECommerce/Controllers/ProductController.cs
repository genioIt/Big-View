using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiEcommerce.Application.App;
using WebApiEcommerce.Application.Entity;
using WebApiEcommerce.Application.Interface;

namespace WebApiECommerce.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplication _productApplication;
        public ProductController(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        [HttpGet("GetByCategoryActive/{idcategory}")]
        public async Task<IActionResult> GetByCategoryActiveAsync(int idcategory)
        {
            var result = await _productApplication.GetByCategoryActiveAsync(idcategory);
            return Ok(result);
        }

    }
}
