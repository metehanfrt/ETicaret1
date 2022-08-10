using AspNetMvcEcommerce.Data;
using AspNetMvcEcommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcEcommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext db;

        public ProductController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Search(string query) //string query string tipinden veriye izin verir
        {
            return View();
        }

        public IActionResult Detail(int? id) //burada veriyi kontrol edip çekip daha sonra view de gösteriyoruz (detail.cshtml)
        {
            if (id == null) //ıd null ise hata ver
            {
                return NotFound();
            }

            var product = db.Products //buna egerlodin denir tabloyu çekerken ilişkili tabloyuda çekmek için kullanırız
                .Include(e => e.ProductImages) //ürünleri çekerken ürün resimlerinide çek dedik "Include" *Include yani dahil et
                .Include(e => e.ProductDetail)
                .Include(e => e.Categories)
                .FirstOrDefault(e => e.Id == id);  //veri tabanından çekip istege göre find ile bulup ilk olanı yada seçip product a atar

            if (product == null) //veri tabanına bak bulamazsan hata ver
            {
                return NotFound();
            }

            var productImages = product.ProductImages.ToList(); //product 
            //ilişkili tablo verilerini kullanmak içinde bu yöntemi kullanırız ama ilk olarak 29. satır altına tablomuzu eklemeliyiz
            var vm = new ProductDetailViewModel()//iki tane veriyi view'e göndereceksem sınıflayarak gönderiyorum
            { //view modellerle 4 tane bilgiyi aynı anda gruplayarak gönderebiliyorum
                Product = product,
                ProductDetail = product.ProductDetail,  //SOL taraftaki değişken onun içine atıyoruz
                ProductImages = productImages,  
                ProductCategories = product.Categories.ToList(), //40. satırdakiyle bu farklı kullanımlar biri üstte yazıyor diğeri direk içine atıyor
            }; 

            return View(vm);
        }
    }
}
