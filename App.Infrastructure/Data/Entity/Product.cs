using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infrastructure.Data.Entity
{
    [Table("Product")]
    public class Product
    {
        public Product()
        {
            ProductImages = new List<ProductImage>();
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

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        #endregion

        #region Navigation Properties

        public virtual List<ProductImage> ProductImages { get; set; }

        public virtual ProductDetail ProductDetail { get; set; }

        public virtual List<Category> Categories { get; set; }

        #endregion
    }
}
