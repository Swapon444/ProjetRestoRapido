


#region Espace de noms utilisés

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace RestoRapido.Models
{
    public class CRabais
    {
        #region Données membres

        // Identifiant unique d'un rabais
        public int RabaisID { get; set; }

        // Nom affiché du repas auquel affecter un rabais
        [Key]
        [ForeignKey("Repas")]
        [DisplayName("Nom du repas")]
        public int RabaisRepasID { get; set; }
        
        // % de rabais à appliquer au repas
        [DisplayName("Rabais en %")]
        [Range(0, 100)]
        public int RabaisPrix { get; set; }

        // Date de début du rabais
        [DataType(DataType.Date)]
        [Display(Name = "Date de début")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RabaisDateDebut { get; set; }

        // Date de fin du rabais
        [DataType(DataType.Date)]
        [Display(Name = "Date de fin")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RabaisDateFin { get; set; }

        /* permettre de lier le rabais à un repas */
        public virtual CRepas Repas { get; set; }

        #endregion
    }
}