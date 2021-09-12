using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Menzy.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "Polje {0} je obavenzo.")]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email nije validan")]

        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Zapamti preglednik?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessage = "Polje {0} je obavenzo.")]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email nije validan")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Polje {0} je obavenzo.")]
        [Display(Name = "Email")]
        [EmailAddress]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email nije validan")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Polje {0} je obavenzo.")]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [Display(Name = "Zapamti me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Polje {0} je obavenzo.")]
        [EmailAddress]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email nije validan")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Polje {0} je obavenzo.")]
        [StringLength(100, ErrorMessage = "{0} mora biti barem {2} znakova duga.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi lozinku")]
        [Compare("Password", ErrorMessage = "Lozinka i potvrda lozinke nisu jednake")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Polje {0} je obavenzo.")]
        [Display(Name = "Ime")]
        [RegularExpression("^[A-Ža-ž]+$", ErrorMessage = "Ime mora sadržavati samo slova")]


        public string Ime { get; set; }
        [Display(Name = "Prezime")]
        [Required(ErrorMessage = "Polje {0} je obavenzo.")]
        
        [RegularExpression("^[A-Ža-ž]+$", ErrorMessage = "Prezime mora sadržavati samo slova")]

        public string Prezime { get; set; }
        [Display(Name = "Naziv fakulteta")]
        public string KojiFaks { get; set; }
        [Required(ErrorMessage = "Polje {0} je obavenzo.")]
        [StringLength(10)]
        [RegularExpression("^[0-9]{10,}$", ErrorMessage = "JMBAG mora sadržavati samo brojke i mora biti dugi 10 znakova")]
        public string JMBAG { get; set; }
        public bool Redovni { get; set; }

    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Polje {0} je obavenzo.")]
        [EmailAddress]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email nije validan")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Polje {0} je obavenzo.")]
        [StringLength(100, ErrorMessage = "{0} mora biti barem {2} znakova.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Loznika")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi lozinku")]
        [Compare("Password", ErrorMessage = "Lozinka i potvrda lozinke nisu jednake")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Polje {0} je obavenzo.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
