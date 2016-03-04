using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        #region Indicateurs pour les allergies

        // Indique si le repas contient du blé (true pour oui, false pour non)
        [DisplayName("Blé")]
        public bool m_boBle { get; set; }

        // Indique si le repas contient du lait (true pour oui, false pour non)
        [DisplayName("Lait")]
        public bool m_boLait { get; set; }

        // Indique si le repas contient des oeufs (true pour oui, false pour non)
        [DisplayName("Oeuf")]
        public bool m_boOeuf { get; set; }

        // Indique si le repas contient des arachides (true pour oui, false pour non)
        [DisplayName("Arachide")]
        public bool m_boArachide { get; set; }

        // Indique si le repas contient du soja (true pour oui, false pour non)
        [DisplayName("Soja")]
        public bool m_boSoja { get; set; }

        // Indique si le repas contient des fruits à coque (true pour oui, false pour non)
        [DisplayName("Fruit à coque")]
        public bool m_boFruitCoque { get; set; }

        // Indique si le repas contient du poisson (true pour oui, false pour non)
        [DisplayName("Poisson")]
        public bool m_boPoisson { get; set; }

        // Indique si le repas contient des sésames (true pour oui, false pour non)
        [DisplayName("Sésame")]
        public bool m_boSesame { get; set; }

        // Indique si le repas contient des crustacés (true pour oui, false pour non)
        [DisplayName("Crustacé")]
        public bool m_boCrustace { get; set; }

        // Indique si le repas contient des mollusques (true pour oui, false pour non)
        [DisplayName("Mollusque")]
        public bool m_boMollusque { get; set; }

        #endregion
        public virtual ICollection<CTable> Tables { get; set; }
        public virtual ICollection<CCommande> CollectionCommande { get; set; }

    }
}