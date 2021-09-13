using System.ComponentModel.DataAnnotations;

namespace Vjezba.Model
{
    public class Usluga
    {
        [Required]
        [Key]
        public int IDUsluga { get; set; }
        public string Naziv { get; set; }
        public int Cijena { get; set; }
        public string MjernaJedinica { get; set; }
        // oznaka grupe kojoj pripada (P je proizvod U je usluga)
        public char OznakaGrupe { get; set; }
    }
}
