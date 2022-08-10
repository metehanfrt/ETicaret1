using App.Infrastructure.Data.Entity;

namespace App.Web.Models
{
    public class ProductDetailViewModel
    {
        public Product Product { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public ProductDetail ProductDetail { get; internal set; }
        public List<Category> ProductCategories { get; internal set; }
    }
}