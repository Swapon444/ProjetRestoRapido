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

        // Identifiant unique d'un repas
        [Key]
        public int m_iRepasId { get; set; }

        // Nom affiché du repas
        [DisplayName("Nom")]
        public string m_strNom { get; set; }
        
        // Prix du repas
        [DisplayName("Prix")]
        public int m_iPrix { get; set; }

        // Description du repas
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
        [DisplayName("Mullusque")]
        public bool m_boMollusque { get; set; }

        #endregion

        /* Collection contenant des CMenuRepas pour permettre de lier le repas
           à des menus */
        public ICollection<CMenuRepas> m_MenuRepas;

        #endregion
    }
}
