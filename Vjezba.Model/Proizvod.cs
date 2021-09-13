using System.ComponentModel.DataAnnotations;

namespace Vjezba.Model
{
    public class Proizvod
    {
        [Required]
        [Key]
        public int IDProizvod { get; set; }
        public string Naziv { get; set; }
        public string MjernaJedinica { get; set; }
        public int Cijena { get; set; }
        // oznaka grupe kojoj pripada (P je proizvod U je usluga)
        public char OznakaGrupe { get; set; }
    }
}
