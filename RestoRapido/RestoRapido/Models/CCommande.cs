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
        [Key]
        public int mCmdID { get; set; }                 // Donnée membre qui représente le numéro de la commande (Clé Primaire)
        
        
       
        [ForeignKey("mUtilisateurClient")]
        [Display(Name = "Nom du Client")]
        public int mCmdClientID { get; set; }           // Donnée membre qui représente le numéro du client (Clé Étrangère)
        
        
        
        [ForeignKey("mCmdResto")]
        [Display(Name = "Nom du Restaurant")]
        public int mCmdRestoID { get; set; }            // Donnée membre qui représente le numéro du restaurant (Clé Étrangère)

        
        
        [ForeignKey("mCmdTable")]
        [Display(Name = "Numéro de la table")]
        public int mCmdTableID { get; set; }            // Donnée membre qui représente le numéro de la table (Clé Étrangère)

     /*   
        
        [ForeignKey("mUtilisateurServer")]
        [Display(Name = "Nom du Serveur")]
        public int mCmdServerID { get; set; }     */      // Donnée membre qui représente le numéro du server (Clé Étrangère)
        
        
        
        // public List<CRepas> mCmdTabRepas { get; set; }        
        public List<string> mCmdTabCommentRepas { get; set; }           // Donnée membre qui représente la liste des commentaires du client sur le repas
        public string mCmdCommentCommandes { get; set; }                // Donnée membre qui représente le commentaire du client concernant la commande
        public double mCmdPrixAvantTaxes { get; set; }                  // Donnée membre qui représente le prix de la commande avant taxes
        public double mCmdPrixTotal { get; set; }                       // Donnée membre qui représente la prix de la commande avec taxes
        public int mCmdStatusCommande { get; set; }                     // Donnée membre qui représente le status de la commande (0 : Commande Passée, 1 : Commande Payée, 2 : Commande Annulée)
        
        
        
        public DateTime mCmdDate { get; set; }                          // Donnée membre qui représente la date de la commande

        
        public virtual Utilisateur mUtilisateurClient { get; set; }     // Donnée membre qui représente le client
        public virtual CResto mCmdResto { get; set; }                   // Donnée membre qui représente le restaurant
        public virtual CTable mCmdTable { get; set; }                   // Donnée membre qui représente la table
       // public virtual Utilisateur mUtilisateurServer { get; set; }     // Donnée membre qui représente le server

        

        public virtual ICollection<CRepas> mCmdColletionRepas { get; set; }     // Donnée membre qui représente la liste des repas commandés



    }
}