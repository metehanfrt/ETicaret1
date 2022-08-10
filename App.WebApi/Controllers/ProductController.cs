using App.Application.Dtos;
using App.Application.Services;
using App.Infrastructure.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace App.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        // Get
        // /api/product
        [HttpGet]
        public List<Product> Get()
        {
            var products = _productService.GetProductsByCategoryId(1);

            return products;
        }

        // Http Post
        // /api/product
        [HttpPost]
        public int Post()
        {
            return 1;
        }

        // Http Put
        // /api/product
        [HttpPut]
        public int Put()
        {
            return 2;
        }

        // Http Delete
        // /api/product
        [HttpDelete]
        public bool Delete(int id)
        {
            var isDeleted = _productService.DeleteProductById(id);

            return isDeleted;
        }

        //[Route("/api/product/getproductid")]
        [Route("getproductbyid/{id}")]
        public ProductPriceDto GetProductPriceById(int id)
        {
            return _productService.GetProductPriceById(id);
        }
    }
}
