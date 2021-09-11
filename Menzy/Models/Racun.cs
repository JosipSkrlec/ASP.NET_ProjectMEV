using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Menzy.Models
{
    public class Racun
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public List<Stavka> Stavka { get; set; }
        public double Price { get; set; }
    }
}