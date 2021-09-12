using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vjezba.Model
{
    public class Korisnik
    {
        [Required]
        public int IDKorisnik { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public DateTime LicencaExp { get; set; }
        public string Vrsta { get; set; }
        [ForeignKey(nameof(Poduzece))]
        public Poduzece IDPoduzece { get; set; }
        //public Poduzece? objAttachmentID { get; set; }
        public bool Aktivan { get; set; }
        public string AktivanLink { get; set; }
    }
}
