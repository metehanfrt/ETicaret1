using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcEcommerce.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
