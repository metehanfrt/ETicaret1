using AspNetMvcEcommerce.Data;

namespace AspNetMvcEcommerce.Models //bu modelin amacı verileri tutarak view kısmına göndermek
{
    public class ProductDetailViewModel
    {
        public Product Product { get; set; } //productr verilerini tutar
        public List<ProductImage> ProductImages { get; set; } //liste olarak productımage tutar
        public ProductDetail ProductDetail { get; internal set; }
        public List<Category> ProductCategories { get; internal set; }
    }
}
