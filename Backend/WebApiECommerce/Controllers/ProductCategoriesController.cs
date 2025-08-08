using Microsoft.AspNetCore.Mvc;
using WebApiEcommerce.Application.Interface;

namespace WebApiECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoriesApplication _ProductCategoriesApplication;

        public ProductCategoriesController(IProductCategoriesApplication ProductCategoriesApplication)
        {
            _ProductCategoriesApplication = ProductCategoriesApplication;
        }

        [HttpGet("GetAllActiveCategories")]
        public async Task<IActionResult> GetActiveAsync()
        {
            var result = await _ProductCategoriesApplication.GetActiveAsync();
            return Ok(result);
        }
    }
}
