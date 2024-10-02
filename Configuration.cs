using System.Data.Entity.Migrations;
using ProjetFrancois.Models;

namespace ProjetFrancois.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DbEcommerce>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; // Activer les migrations automatiques
            AutomaticMigrationDataLossAllowed = true; // Autoriser la perte de données lors de migrations automatiques
            ContextKey = "ProjetFrancois.Models.DbEcommerce"; // Clé du contexte de base de données
        }

        protected override void Seed(DbEcommerce context)
        {
            // Ajoutez ici les données semées si nécessaire
        }
    }
}

