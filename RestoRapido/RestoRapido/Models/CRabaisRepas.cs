


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
    public class CRabaisRepas
    {
        #region Données membres

        // Identifiant unique d'un rabais
        [Key]
        public int RabaisID { get; set; }

        // Nom affiché du repas auquel affecter un rabais
        [DisplayName("Nom du repas")]
        public int m_iRepasId { get; set; }

        // % de rabais à appliquer au repas
        [DisplayName("Rabais en %")]
        public int RabaisPrix { get; set; }

        // Date de début du rabais
        [DisplayName("Date de début")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RabaisDateDebut { get; set; }

        // Date de fin du rabais
        [DisplayName("Date de fin")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RabaisDateFin { get; set; }

        public virtual CRepas Repas { get; set; }
        #endregion
    }
}