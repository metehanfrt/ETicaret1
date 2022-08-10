using System.ComponentModel.DataAnnotations;

namespace App.Web.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Bu alan gerekli")]
        [EmailAddress(ErrorMessage = "Email adresi geçerli değil")]
        [StringLength(150)]
        [Display(Name = "Email")]
        public string? EmailAddress { get; set; }

        [Required(ErrorMessage = "Bu alan gerekli")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Bu alan gerekli")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrarı")]
        [Compare("Password", ErrorMessage = "Şifre ve tekrarı aynı olmalıdır")]
        public string? PasswordConfirm { get; set; }
    }
}
