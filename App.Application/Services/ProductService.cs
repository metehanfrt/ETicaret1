using App.Application.Dtos;
using App.Infrastructure.Data;
using App.Infrastructure.Data.Entity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public ProductService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public Product GetProductById(int productId)
        {
            var product = db.Products
                .Include(e => e.ProductImages)
                .Include(e => e.ProductDetail)
                .Include(e => e.Categories)
                .FirstOrDefault(e => e.Id == productId);

            return product;
        }

        public ProductPriceDto GetProductPriceById(int productId)
        {
            var product = db.Products.FirstOrDefault(e => e.Id == productId);

            return mapper.Map<ProductPriceDto>(product);
        }

        public List<Product> GetProductByQuery(string query)
        {
            var products = db.Products
                .Include(e => e.ProductImages)
                .Where(e => e.Name.Contains(query) || e.Description.Contains(query))
                .ToList();

            return products;
        }

        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            var products = db.Products
                .Include(e => e.ProductImages)
                .Where(e => e.Categories.Select(e => e.Id).Contains(categoryId))
                .ToList();

            return products;
        }

        public bool DeleteProductById(int id)
        {
            var product = db.Products.FirstOrDefault(e => e.Id == id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
