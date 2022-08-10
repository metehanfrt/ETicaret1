using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcEcommerce.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int orderId)
        {
            return View();
        }
    }
}
