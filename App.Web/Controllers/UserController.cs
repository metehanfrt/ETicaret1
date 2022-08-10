using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class UserController : Controller
    {
        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }
    }
}