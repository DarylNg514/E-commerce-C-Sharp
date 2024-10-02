using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetFrancois.Models
{
    public class panier
    {
        [Key]
        public int IdPanier { get; set; }
        public string image { get; set; }
        public double prix { get; set; }
    }
}