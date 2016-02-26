using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestoRapido.Models
{
    public class Utilisateur
    {
        [Display(Name = "ID")]
        [Required]
        [Key]
        public int UtilisateurID { get; set; }
        [Display(Name = "Mot de passe")]
        [Required]
        public string UtilisateurMDP { get; set; }
        [Display(Name = "Nom d'usager")]
        [Required]
        public string UtilisateurNomUsager { get; set; }
        [Display(Name = "Nom")]
        [Required]
        public string UtilisateurNom { get; set; }
        [Display(Name = "Prénom")]
        [Required]
        public string UtilisateurPrenom { get; set; }
        [Display(Name = "Type")]
        [Required]
        public string UtilisateurType { get; set; }

        public virtual ICollection<CTableUtilisateurs> TableUtilisateur { get; set; }
    }
}