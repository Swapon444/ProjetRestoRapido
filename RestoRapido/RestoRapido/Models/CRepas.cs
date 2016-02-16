using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestoRapido.Models
{
    public class CRepas
    {
        [Key]
        public int mRepID { get; set; }
        public int mRepNom { get; set; }

    }
}