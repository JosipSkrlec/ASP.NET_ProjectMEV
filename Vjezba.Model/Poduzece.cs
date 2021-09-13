using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Vjezba.Model
{
    public class Poduzece
    {
        [Required]
        [Key]
        public int IDPoduzece { get; set; }
        //[Required(ErrorMessage = "Name is required")]
        public string Naziv { get; set; }
        //[Required(ErrorMessage = "Surname is required")]
        public string Adresa { get; set; }
        //[Required(ErrorMessage = "Email is required")]
        public string Grad { get; set; }
        public string Drzava { get; set; }
        public int Tel { get; set; }
        public int Mob { get; set; }
        public string Email { get; set; }
        public long OIB{ get; set; }
        public string OdgovornaOsoba { get; set; }
        public int ZiroRacun { get; set; }
        public string Banka { get; set; }
        public int PDV { get; set; }
        public string Biljeska { get; set; }
    }
}
