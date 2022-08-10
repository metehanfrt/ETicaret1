using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvcEcommerce.Data
{
    [Table("ProductDetail")]
    public class ProductDetail
    {
        public int Id { get; set; }
        
        public int ProductId { get; set; }

        public bool IsVisibleSlider { get; set; }

        public bool IsVisibleFeatured { get; set; }

        // Navigation Properties
        public Product Product { get; set; }
    }
}
 