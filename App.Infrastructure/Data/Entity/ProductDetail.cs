using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infrastructure.Data.Entity
{
    [Table("ProductDetail")]
    public class ProductDetail
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public bool IsVisibleSlider { get; set; }

        public bool IsVisibleFeatured { get; set; }

        // Navigation Properties
        public virtual Product Product { get; set; }
    }
}
