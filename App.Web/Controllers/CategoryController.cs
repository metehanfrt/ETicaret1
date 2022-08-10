using App.Application.Services;
using App.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;

        public CategoryController(ProductService productService, CategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Products(int categoryId)
        {
            var products = _productService.GetProductsByCategoryId(categoryId);

            var activeCategory = _categoryService.GetCategoryById(categoryId);

            var model = new ProductListViewModel
            {
                ActiveCategory = activeCategory,
                AllCategories = _categoryService.GetAllCategories(),
                Products = products
            };

            return View(model);
        }
    }
}