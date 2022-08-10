using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcEcommerce.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Products()
        {
            return View();
        }
    }
}
