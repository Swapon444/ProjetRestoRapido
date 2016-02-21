using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace RestoRapido.Models
{
    public class CRepas
    {
        [Key]
        public int mRepID { get; set; }

        public int mRepNom { get; set; }




        public virtual ICollection<CCommande> mRepColletionCommande { get; set; }     // Donnée membre qui représente la liste des repas commandés




    }
}