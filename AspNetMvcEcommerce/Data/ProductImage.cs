using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvcEcommerce.Data
{
    [Table("ProductImage")]
    public class ProductImage
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [MaxLength(100)]
        public string ImageUrl { get; set; }

        // Navigation Properties
        public Product Product { get; set; }
    }
}
