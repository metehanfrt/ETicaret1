using AspNetMvcEcommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcEcommerce.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent //ViewComponent'den kalıtım aldık
    {
        private readonly ApplicationDbContext _db;

        public CategoriesViewComponent(ApplicationDbContext db)
        {
            _db = db; //local değişkeni global değişkene dönüştük
        }

        public async Task<IViewComponentResult> InvokeAsync() //
        {
            var categories = await _db.Categories.ToListAsync();

            return View(categories); //** Shared/Component/Categories/Default'a gönderiyor
        }
    }
}
