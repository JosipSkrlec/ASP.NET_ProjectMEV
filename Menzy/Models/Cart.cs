using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Menzy.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public double Price { get; set; }
    }
}