using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infrastructure.Data.Entity
{
    [Table("ProductImage")]
    public class ProductImage
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [MaxLength(100)]
        public string ImageUrl { get; set; }

        // Navigation Properties
        public virtual Product Product { get; set; }
    }
}
