using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RestoRapido.Models
{
    public class CResto
    {
        public int CRestoID { get; set; }

        [DisplayName("Nom du restaurant")]
        public string resNom { get; set; }
        [DisplayName("Code postal")]
        public string resPostal { get; set; }
        [DisplayName("Rue")]
        public string resRue { get; set; }
        [DisplayName("Numéro Civil")]
        public string resNoCiv { get; set; }

        public ICollection<CTable> Tables { get; set; }
    }
}