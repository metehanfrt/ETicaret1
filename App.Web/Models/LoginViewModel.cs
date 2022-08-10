using System.ComponentModel.DataAnnotations;

namespace App.Web.Models
{
    public class LoginViewModel
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

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
