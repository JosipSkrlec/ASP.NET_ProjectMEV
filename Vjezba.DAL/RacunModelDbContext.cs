using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Vjezba.Model;

namespace Vjezba.DAL
{
    public class RacunModelDbContext : IdentityDbContext<AppUser>
    {
        public RacunModelDbContext(DbContextOptions<RacunModelDbContext> options) : base(options) { }

        public DbSet<Korisnik> korisnik { get; set; }
        public DbSet<Kupac> kupac { get; set; }
        public DbSet<Poduzece> poduzece { get; set; }
        public DbSet<Racun> racun { get; set; }
        public DbSet<RacunStavka> racunStavka { get; set; }
        public DbSet<Usluge> usluge { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Korisnik>().HasData(new Korisnik { IDKorisnik = 1, Ime = "Ivan", Prezime = "Bockal", Email = "IvanB@gmail.com", Password = "!1Ivan123", LicencaExp = DateTime.Now, Vrsta = "ObicanKorisnik", Aktivan = true, AktivanLink = "AktivanLink" });
            modelBuilder.Entity<Korisnik>().HasData(new Korisnik { IDKorisnik = 2, Ime = "Ivan2", Prezime = "Bockal2", Email = "IvanB2@gmail.com", Password = "!1Ivan123", LicencaExp = DateTime.Now, Vrsta = "ObicanKorisnik", Aktivan = false, AktivanLink = "AktivanLink2" });
            modelBuilder.Entity<Korisnik>().HasData(new Korisnik { IDKorisnik = 3, Ime = "Ivan3", Prezime = "Bockal3", Email = "IvanB3@gmail.com", Password = "!1Ivan123", LicencaExp = DateTime.Now, Vrsta = "NeobicanKorisnik", Aktivan = true, AktivanLink = "AktivanLink3" });

            modelBuilder.Entity<Kupac>().HasData(new Kupac { IDKupac = 1, Naziv = "Ivan", Adresa = "Zagorska3", Grad = "Konjscina", Drzava = "Hrvatska", OIB = 12345678912 });
            modelBuilder.Entity<Kupac>().HasData(new Kupac { IDKupac = 2, Naziv = "Ivan2", Adresa = "Zagorska34", Grad = "Konjscina2", Drzava = "Hrvatska2", OIB = 12345678956 });
            modelBuilder.Entity<Kupac>().HasData(new Kupac { IDKupac = 3, Naziv = "Ivan3", Adresa = "Zagorska35", Grad = "Konjscina3", Drzava = "Hrvatska3", OIB = 12345678987 });

            // TODO - napraviti ostale migracijske skripte

        }
    }
}
