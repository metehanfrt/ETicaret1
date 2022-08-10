using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infrastructure.Data.Entity
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        [Column(TypeName = "nvarchar(150)")]
        public string? EmailAddress { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        public string? Name { get; set; }

        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        public string? Surname { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string? Roles { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string? ActivationKey { get; set; }

        public bool IsActive { get; set; }
    }
}
