using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Menzy.Models
{
    public class Food
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Polje {0} je obavenzo.")]

        [RegularExpression("^[A-Ža-ž]+$", ErrorMessage = "Naziv mora sadržavati samo slova")]
        [Display(Name = "Naziv ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Polje {0} je obavenzo.")]

        [RegularExpression("^[0-9]+$", ErrorMessage = "Cijena mora sadržavati samo brojke")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Polje {0} je obavenzo.")]
        [Display(Name = "Tip hrane")]
        public string TipHrane { get; set; }

        

    }
}