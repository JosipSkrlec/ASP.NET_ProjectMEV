using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Vjezba.Model
{
    public class AppUser : IdentityUser
    {
        // DODANO
        [Required]
        [RegularExpression("[0-9]{13}")]
        public string Name { get; set; }
        [Required]
        [RegularExpression("[0-9]{13}")]
        public string Surname { get; set; }
        // DODANO DO OVDJE

        [Required]
        [RegularExpression("[0-9]{13}")]
        public string JMBG { get; set; }
        [Required]
        [RegularExpression("[0-9]{11}")]
        public string OIB { get; set; }
    }
}
