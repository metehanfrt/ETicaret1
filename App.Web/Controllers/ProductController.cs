using App.Application.Services;
using App.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult Search(string query)
        {
            var products = _productService.GetProductByQuery(query);

            ViewBag.Query = query;

            return View(products);
        }

        public IActionResult Detail([Bind(Prefix = "id")] int? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            var product = _productService.GetProductById((int)productId);

            if (product == null)
            {
                return NotFound();
            }

            var productImages = product.ProductImages.ToList();

            var vm = new ProductDetailViewModel()
            {
                Product = product,
                ProductDetail = product.ProductDetail,
                ProductImages = productImages,
                ProductCategories = product.Categories.ToList(),
            };

            return View(vm);
        }
    }
}