using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Vjezba.Model
{
    public class Kupac
    {
        [Required]
        public int IDKupac { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
        public string Drzava { get; set; }
        public long OIB { get; set; }
    }
}
