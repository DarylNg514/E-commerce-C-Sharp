using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetFrancois.Models
{
    public class user
    {
        [Key]
        public int iduser { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string Telephone { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int titre { get; set; }
    }
}