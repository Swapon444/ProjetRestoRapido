using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestoRapido.Models
{
    public class CAlerte
    {
        [Required]
        [Key]
        public int AlerteID { get; set; }
        [Required]
        public int UtilisateurID { get; set; }
        [Required]
        public int CTableID { get; set; }
    }
}