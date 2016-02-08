using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoRapido.Models
{
    public class Utilisateur
    {
        public int UtilisateurID { get; set; }
        public string UtilisateurMDP { get; set; }
        public string UtilisateurNomUsager { get; set; }
        public string UtilisateurNom { get; set; }
        public string UtilisateurPrenom { get; set; }
        public string UtilisateurType { get; set; }
    }
}