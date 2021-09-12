using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vjezba.Model
{
    public class Racun : IdentityUser
    {
        [Required]
        public int IDRacun { get; set; }
        public DateTime Datum { get; set; }
        [ForeignKey(nameof(Poduzece))]
        public Poduzece IDPoduzece { get; set; }
        [ForeignKey(nameof(Korisnik))]
        public Korisnik IDKorisnik { get; set; }
        public string Naslov { get; set; }
        public int Iznos { get; set; }
        public int PDV { get; set; }
        public string Oznaka { get; set; }
        public DateTime VrijemeIzdavanja { get; set; }
    }
}
