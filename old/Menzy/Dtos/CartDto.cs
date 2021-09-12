using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Menzy.Models;

namespace Menzy.Dtos
{
    public class CartDto
    {
        public int Id { get; set; }
        [Required] public Food Food { get; set; }
        public int Broj { get; set; }
        public double Price { get; set; }
    }
}