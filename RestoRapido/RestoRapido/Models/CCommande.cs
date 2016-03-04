using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestoRapido.Models
{
    public class CCommande
    {
        // Donnée membre qui représente le numéro de la commande (Clé Primaire)
        [Key]
        public int mCmdID { get; set; }

        // Donnée membre qui représente le status de la commande 
        // (0 : Commande Passée, 1 : Commande Payée, 2 : Commande Annulée)
        public int mCmdStatusCommande { get; set; }

        // Donnée membre qui représente le numéro du client (Clé Étrangère)
        [Display(Name = "Nom du Client")]
        public int UtilisateurID { get; set; }         
        public virtual Utilisateur mUtilisateurClient { get; set; }

        // Donnée membre qui représente le numéro du restaurant (Clé Étrangère)
        [Display(Name = "Nom du Restaurant")]
        public int CRestoID { get; set; }            
        public virtual CResto mCmdResto { get; set; }

        // Donnée membre qui représente le numéro de la table (Clé Étrangère)
        [Display(Name = "Numéro de la table")]
        public int CTableID { get; set; }           
        public virtual CTable mCmdTable { get; set; }                  


        // Donnée membre qui représente la liste des repas commandés
        public virtual ICollection<CRepas> mCmdColletionRepas { get; set; }

        // Donnée membre qui représente la liste des commentaires du client sur le repas
        public List<string> mCmdTabCommentRepas { get; set; }

        // Donnée membre qui représente le commentaire du client concernant la commande
        [Display(Name = "Commentaires sur la commande")]
        public string mCmdCommentCommandes { get; set; }

        // Donnée membre qui représente le prix de la commande avant taxes
        [Display(Name = "Prix avant Taxes")]
        [DataType(DataType.Currency)]
        public decimal mCmdPrixAvantTaxes { get; set; }

        // Donnée membre qui représente la prix de la commande avec taxes
        [DataType(DataType.Currency)]
        [Display(Name = "Prix Total")]
        public decimal mCmdPrixTotal { get; set; }

        //Donnée membre qui représente la date de la commande
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime mCmdDate { get; set; }

    }
}