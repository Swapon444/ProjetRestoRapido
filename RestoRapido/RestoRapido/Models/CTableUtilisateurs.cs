using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestoRapido.Models
{
    public class CTableUtilisateurs
    {

        public int CTableID { get; set; }
        public virtual CTable Table { get; set; }

        public int UtilisateurID { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
    }
}