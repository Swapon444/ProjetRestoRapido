using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestoRapido.Models
{

        public class CCommandeContext : DbContext
        {
            public DbSet<CCommande> mCommandes { get; set; }
        }




    
}