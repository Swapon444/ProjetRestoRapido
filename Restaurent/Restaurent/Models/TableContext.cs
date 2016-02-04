using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Restaurent.Models
{
    //Format de la database
    public class TableContext : DbContext
    {
        //Tbl des tables de restaurants
        public DbSet<CTable> tblTables { get; set; }

        /*
        //Tbl des codes QR
        public DbSet<CCodeQR> CodesQR { get; set; }
        */
    }
}