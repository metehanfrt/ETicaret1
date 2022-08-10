using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Detail(int pageId)
        {
            return View();
        }
    }
}
