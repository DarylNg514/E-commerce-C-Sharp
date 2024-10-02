using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetFrancois.Models
{
    public class category
    {
        [Key]
        public int IdCategorie { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }


        //Relation avec Produits
        public virtual List<produit> Produit { get; set; }

    }
}