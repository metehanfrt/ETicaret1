using AspNetMvcEcommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcEcommerce.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;

        public SliderViewComponent(ApplicationDbContext db)
        {
            _db = db; //local değişkeni global değişkene dönüştük
        }

        public async Task<IViewComponentResult> InvokeAsync() //
        {
            var products = await _db.Products
                .Include(e=>e.ProductImages) //veri tabanından çekip resimleri sliderde göstermek için Include kullandık
                .ToListAsync();

            return View(products); //** Shared/Component/Categories/Default'a gönderiyor
        }
    }
}
