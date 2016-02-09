using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestoRapido.Models
{
    public class RestoContext : DbContext
    {
        public DbSet<Resto> tabResto { get; set; }
    }
}