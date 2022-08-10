using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvcEcommerce.Data
{
    [Table("Product")]
    public class Product
    {
        public Product() //null gelirse category patlar hata verir bunu patlamaması için kurduk  
        {
            ProductImages = new List<ProductImage>(); //navigation ile bağlantılı ilk çalıştırdığımızda resimler boş gelmesin nll
            Categories = new List<Category>();
        }

        #region Properties
        public int Id { get; set; }

        [MaxLength(100)]
        public string? SKU { get; set; }

        [MaxLength(160)]
        public string? Slug { get; set; }

        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal Price { get; set; }

        public DateTime CreatetAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        #endregion

        #region Navigation Properties

        public List<ProductImage> ProductImages { get; set; }

        public ProductDetail ProductDetail { get; set; }

        public List<Category> Categories { get; set; }
        
        #endregion
    }
}
