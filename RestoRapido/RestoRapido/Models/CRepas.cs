using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoRapido.Models
{
    public class CRepas
    {
        public int mRepID { get; set; }





        public ICollection<CCommande> collectionCommandes { get; set; }
    }
}