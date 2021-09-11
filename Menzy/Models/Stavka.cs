using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Menzy.Models {
    public class Stavka {

        public int Id { get; set; }
        public Food Food { get; set; }
        public int Quantity { get; set; }
        public Racun Racun { get; set; }
    }
}