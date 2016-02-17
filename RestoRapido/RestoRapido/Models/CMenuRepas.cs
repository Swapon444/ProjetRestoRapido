/*
+++++++++++++++++++++
+ Classe CMenuRepas +
+++++++++++++++++++++

++++++++++++++++++++++++++++++++++++++++
+ Auteur : Marc Deslandes - 420-W63-JO +
++++++++++++++++++++++++++++++++++++++++
*/

#region Espace de noms utilisés

using System.ComponentModel.DataAnnotations;

#endregion

namespace RestoRapido.Models
{
    /// <summary>
    /// Classe qui permet d'effectuer une liaison de plusieurs à plusieurs avec
    /// les classes CMenu et CRepas
    /// </summary>
    public class CMenuRepas
    {
        #region Données membres

        // Identifiant unique de la classe
        [Key]
        public int m_iMenuRepasId { get; set; }

        // Référence vers l'identifiant d'un menu
        public int m_iMenuId { get; set; }

        // Référence vers un menu
        public CMenu m_Menu { get; set; }

        // Référence vers l'identifiant d'un repas
        public int m_iRepasId { get; set; }

        // Référence vers un repas
        public CRepas m_Repas { get; set; }

        #endregion
    }
}
