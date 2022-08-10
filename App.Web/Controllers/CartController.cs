using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
