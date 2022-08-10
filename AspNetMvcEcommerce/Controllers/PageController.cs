using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcEcommerce.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Detail(int pageId)
        {
            return View();
        }
    }
}
