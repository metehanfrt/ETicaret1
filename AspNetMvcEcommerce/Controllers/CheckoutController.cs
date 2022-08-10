using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcEcommerce.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
