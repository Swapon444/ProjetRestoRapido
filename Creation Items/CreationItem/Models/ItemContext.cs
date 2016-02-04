using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CreationItem.Models
{
    public class ItemContext
    {
        public DbSet<Item> Items { get;  set; }
    }
}