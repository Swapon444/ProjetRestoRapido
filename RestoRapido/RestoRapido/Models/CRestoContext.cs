using System;
using System.Collections.Generic;
using System.Data.Entity;
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

    }
}