using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetFrancois.Models
{
    public class DbEcommerce : DbContext
    {
        public DbSet<user> user { get; set; }
        public DbSet<panier> panier { get; set; }
        public DbSet<produit> produit { get; set; }
        public DbSet<category> category { get; set; }
    }
}