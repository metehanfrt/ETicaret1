using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infrastructure.Data.Entity
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Üst Kategori")]
        public int? ParentId { get; set; }

        [MaxLength(40)]
        public string? Slug { get; set; }

        [Required]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Navigation Property
        public virtual ICollection<Product> Products { get; set; }

        [ForeignKey("ParentId")]
        public virtual Category ParentCategory { get; set; }
    }
}
