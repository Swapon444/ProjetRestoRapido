using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoRapido.Models
{
    public class Resto
    {
        public int resID { get; set; }
        public string resNom { get; set; }
        public string resPostal { get; set; }
        public string resRue { get; set; }
        public int resNoCiv { get; set; }
    }
}