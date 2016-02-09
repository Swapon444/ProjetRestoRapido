/*
++++++++++++++++
+ Classe CMenu +
++++++++++++++++

++++++++++++++++++++++++++++++++++++++++
+ Auteur : Marc Deslandes - 420-W63-JO +
++++++++++++++++++++++++++++++++++++++++
*/

#region Espace de noms utilisés

using System.Collections;

#endregion

namespace RestoRapido.Models
{
    /// <summary>
    /// Classe qui représente un menu contenant des repas
    /// </summary>
    public class CMenu
    {
        #region Données membres

        // Identifiant unique du menu
        public int m_iMenuId { get; set; }

        // Nom affiché du menu       
        public string m_strNom { get; set; }

        // Indique la date ou le menu commencera à être actif     
        public string m_strDateDebut { get; set; }

        // Indique la date ou le menu finit d'être actif
        public string m_strDateFin { get; set; }

        // Collection contenant les repas du menu
        // public ICollection/*<CRepas>*/ m_Repas;  

        #endregion
    }
}