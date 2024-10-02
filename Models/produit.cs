using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetFrancois.Models
{
    public class produit
    {
        [Key]
        public int idproduit { get; set; }
        public string image { get; set; }
        public double prix { get; set; }
        //Relation avec categorie
        public int IdCategorie { get; set; }
        public virtual category Categorie { get; set; }
    }
}