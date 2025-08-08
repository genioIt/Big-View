using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApiEcommerce.Application.Interface;
using WebApiEcommerce.Application.Model;

namespace WebApiECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthApplication _authApplication;

        public AuthController(IAuthApplication authApplication)
        {
            _authApplication = authApplication;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            var result = await _authApplication.Login(request.Email, request.Password);
            return result is null ? Unauthorized() : Ok(result);
        }
    }
}
