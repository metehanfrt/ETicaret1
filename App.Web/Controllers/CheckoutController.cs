using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
