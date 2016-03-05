using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace RestoRapido.Models
{
    public class CRestoContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<CTable> Tables { get; set; }
        public DbSet<CMenu> Menus { get; set; }
        public DbSet<CResto> Resto { get; set; }
        public DbSet<CCommande> Commandes { get; set; }
        public DbSet<CRepas> Repas { get; set; }
        public DbSet<CRabaisRepas> Rabais { get; set; }
        public DbSet<CAlerte> Alertes { get; set; }   
        public DbSet<CTableUtilisateurs> TableUtilisateurs { get; set; }
        public DbSet<CCmdRepas> CommandeRepas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
    }

}