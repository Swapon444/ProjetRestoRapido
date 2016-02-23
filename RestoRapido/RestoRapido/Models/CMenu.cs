/*
++++++++++++++++
+ Classe CMenu +
++++++++++++++++

++++++++++++++++++++++++++++++++++++++++
+ Auteur : Marc Deslandes - 420-W63-JO +
++++++++++++++++++++++++++++++++++++++++
*/

#region Espace de noms utilisés

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace RestoRapido.Models
{
    /// <summary>
    /// Classe qui représente un menu contenant des repas
    /// </summary>
    public class CMenu
    {
        #region Données membres

        // Identifiant unique d'un menu
        [Key]
        public int m_iMenuId { get; set; }

        // Nom affiché du menu      
        [DisplayName("Nom")]
        public string m_strNom { get; set; }

        // Indique la date ou le menu commencera à être actif     
        [DisplayName("Date de début")]
        public DateTime m_DateDebut { get; set; }

        // Indique la date ou le menu finit d'être actif
        [DisplayName("Date de fin")]
        public DateTime m_DateFin { get; set; }

        /* Collection contenant des CRepas pour permettre de lier le menu à
           des repas */
        public ICollection<CRepas> m_Repas;

        #endregion
    }
}