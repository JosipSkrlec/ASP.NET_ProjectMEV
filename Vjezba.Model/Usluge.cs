using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Vjezba.Model
{
    public class Usluge : IdentityUser
    {
        [Required]
        public int IDUsluga { get; set; }
        public string Naziv { get; set; }
        public int Cijena { get; set; }
        public string MjernaJedinica { get; set; }
    }
}
