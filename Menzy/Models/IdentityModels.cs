using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Menzy.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Ime")]
        [Required(ErrorMessage = "Polje {0} je obavenzo.")]

        [RegularExpression("^[A-Ža-ž]+$", ErrorMessage = "Prezime mora sadržavati samo slova")]
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

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Racun> Racuns {get; set; }
        public DbSet<Stavka> Stavkas {get; set; }

    public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}