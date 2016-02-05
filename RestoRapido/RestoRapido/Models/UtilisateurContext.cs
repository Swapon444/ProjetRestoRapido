using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestoRapido.Models
{
    public class UtilisateurContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get; set; }
    }
}