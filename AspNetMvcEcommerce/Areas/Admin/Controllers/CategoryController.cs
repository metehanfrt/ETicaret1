#nullable disable
using AspNetMvcEcommerce.Data;
using AspNetMvcEcommerce.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcEcommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Category
        public async Task<IActionResult> Index(int? parentId = null)
        {
            ViewBag.allCategories = GetCategories(); //Admin/Category/Index parentId kısımında kullanacağız bunu

            var query = _context.Categories.Select(e => e); //tüm kategorileri çek
            if (parentId.HasValue) //eğer parentID değeri varsa
            {
                query = query.Where(e => e.ParentId == parentId);
            }

            var list = await query.ToListAsync();

            return View(list);
        }

        // GET: Admin/Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Admin/Category/Create
        public IActionResult Create()
        {
            ViewBag.allCategories = GetCategories(); //veri tabanındaki tüm kategorileri çeker 

            return View();
        }

        private List<SelectListItem> GetCategories() //Tüm kategorileri çeken fonksiyon bunun içinde ayıklama listeleme vs yapıyoruz
        { //Category Index e veri gönderiyoruz
            var allCategories = _context.Categories.ToList(); 
            var list = allCategories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });

            return list.ToList();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParentId,Slug,Name,Description,CreatetAt,UpdatedAt,DeletedAt")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.CreatetAt = DateTime.Now;
                if (String.IsNullOrEmpty(category.Slug))
                {
                    category.Slug = category.Name.GenerateSlug(); //Helper klasörümüzdeki slug yapma kodunu this sayasinde çektik
                }

                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Admin/Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.allCategories = GetCategories();

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ParentId,Slug,Name,Description,CreatetAt,UpdatedAt,DeletedAt")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    category.UpdatedAt = DateTime.Now; // güncelleme yapıyoruz
                    if (String.IsNullOrEmpty(category.Slug))
                    {
                        category.Slug = category.Name.GenerateSlug(); //helpers teki url helpers'i this koyup direk çektik ve kullandık 
                    }

                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Admin/Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
