/*
+++++++++++++++++
+ Classe CRepas +
+++++++++++++++++

++++++++++++++++++++++++++++++++++++++++
+ Auteur : Marc Deslandes - 420-W63-JO +
++++++++++++++++++++++++++++++++++++++++
*/

#region Espace de noms utilisés

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace RestoRapido.Models
{
    /// <summary>
    /// Classe qui représente un repas dans un menu
    /// </summary>
    public class CRepas
    {
        #region Données membres

        // Identifiant unique du repas
        [Key]
        public int m_iRepasId { get; set; }

        // Nom affiché du repas
        [Required]
        [DisplayName("Nom")]
        [StringLength(50, MinimumLength = 1)]
        public string m_strNom { get; set; }


        public string m_imgImage { get; set; }
/*
        // Prix du repas
        [Required]
        [DisplayName("Prix")]
        [Range(0, int.MaxValue)]
        public int m_iPrix { get; set; }
        */

        [DataType(DataType.Currency)]
        [Display(Name = "Prix Total")]
        public decimal m_iPrix { get; set; }


        // Description du repas
        [DataType(DataType.MultilineText)]
        [DisplayName("Description")]
        public string m_strDescription { get; set; }

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

        /* Collection contenant des CMenus pour permettre de lier le repas
           à des menus */
        public virtual ICollection<CMenu> m_Menus { get; set; }
        public virtual ICollection<CCmdRepas> RepasCommandes { get; set; }
        public virtual ICollection<CRabaisRepas> RepasRabais { get; set; }

        #endregion
    }
}
