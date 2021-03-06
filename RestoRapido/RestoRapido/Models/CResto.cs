﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestoRapido.Models
{
    public class CResto
    {
        [Key]
        public int CRestoID { get; set; }

        [DisplayName("Nom du restaurant")]
        public string resNom { get; set; }
        [DisplayName("Code postal")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "Assurez-vous d'entrer un code postal complet")]
        [RegularExpression(@"^[A-Z]\d[A-Z] \d[A-Z]\d$", ErrorMessage = "Le code postal doit être au format A1A 1A1")]
        public string resPostal { get; set; }
        [DisplayName("Rue")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Veuillez entrer des caractères valides")]
        public string resRue { get; set; }
        [DisplayName("Numéro civique")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Veuillez entrer le numéro de l'adresse")]
        public string resNoCiv { get; set; }

        public virtual ICollection<CTable> Tables { get; set; }
        public virtual ICollection<CCommande> RestoCommande { get; set; }


        //public virtual ICollection<CCommande> Commandes { get; set; }
    }
}