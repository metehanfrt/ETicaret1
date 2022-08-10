using App.Infrastructure.Data.Entity;

namespace App.Web.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
        public Category ActiveCategory { get; set; }
        public List<Category> AllCategories { get; set; }
    }
}