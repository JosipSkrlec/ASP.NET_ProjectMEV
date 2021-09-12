using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vjezba.Model
{
    public class RacunStavka
    {
        // dodana vise jer idracun vec postoji za racun koji je foreign key
        [Required]
        public int IDRacunStavka { get; set; }
        public DateTime Datum { get; set; }
        [ForeignKey(nameof(Racun))]
        public Racun IDRacun { get; set; }
        [ForeignKey(nameof(Usluga))]
        public Usluga IDUsluga { get; set; }
        public int Kolicina { get; set; }
        public int Cijena { get; set; }
        public int Rabat{ get; set; }
    }
}
