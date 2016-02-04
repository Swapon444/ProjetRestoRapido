using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
/*
++++++++++++++++++++++++++++
+ Classe CTableInitializer +
++++++++++++++++++++++++++++


+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

+ Auteur: Francis Verreault       -      420-W63-JO       +

+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

*/
namespace Restaurent.Models
{
    public class CTableInitializer : DropCreateDatabaseIfModelChanges<TableContext>
    {
        protected override void Seed(TableContext Context)
        {
            /*
            var CodeQR = new List<CCodeQR>
            {
                new CCodeQR { i_CodeQRID =  1}
            };

            foreach(var temp in CodeQR)
            {
                Context.CodesQR.Add(temp);
            }
            */

            var table = new List<CTable>
            {
                new CTable { i_TableNum= 1, i_TableID= 1, i_RestaurantID= 1, }
            };

            foreach (var temp in table)
            {
                Context.tblTables.Add(temp);
            }

            Context.SaveChanges();
        }
    }
}