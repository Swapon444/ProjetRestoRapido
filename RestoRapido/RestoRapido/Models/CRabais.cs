


#region Espace de noms utilisés

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#endregion

namespace RestoRapido.Models
{
    public class CRabais
    {
        #region Données membres

        // Identifiant unique d'un rabais
        [Key]
        public int RabaisID { get; set; }

        // Nom affiché du repas auquel affecter un rabais
        [DisplayName("Nom du repas")]
        public int RabaisRepasID { get; set; }


        
        // % de rabais à appliquer au repas
        [DisplayName("Rabais en %")]
        public int RabaisPrix { get; set; }

        // Date de début du rabais
        [DisplayName("Date de début")]
        public string RabaisDateDebut { get; set; }

        // Date de fin du rabais
        [DisplayName("Date de fin")]
        public string RabaisDateFin { get; set; }

        /* Collection contenant des CMenuRepas pour permettre de lier le repas
           à des menus 
        public ICollection<CMenuRepas> m_MenuRepas;*/

        #endregion
    }
}