using Microsoft.AspNetCore.Mvc;

namespace WebApiECommerce.Controllers
{
    public class UserRolesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
