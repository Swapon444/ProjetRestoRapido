using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
/*
++++++++++++++++++++
+  Classe CTable   +
++++++++++++++++++++


+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

+ Auteur: Francis Verreault       -      420-W63-JO       +

+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
*/
namespace Restaurent.Models
{
    //Classe représentant une table dans un restaurant
    [Table("infoTable")]
    public class CTable
    {
        //Identificateur unique de la table
        [Key]
        public int i_TableID { get; set; }

        //Numéro de la table
        public int i_TableNum { get; set; }

        /*
        //Code QR de la table
        public CCodeQR cqr_TableCodeQR { get; set; }
        */

        //ID de restaurant
        public int i_RestaurantID { get; set; }
        
        public ICollection<CTable> Tables { get; set; }
        
    }
}