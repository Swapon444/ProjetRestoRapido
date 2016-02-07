using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoRapido.Models
{
    public class CCommande
    {

        public int mCmdID { get; set; }          // Donnée membre qui représente le numéro de la commande (Clé Primaire)
        public int mCmdClientID { get; set; }    // Donnée membre qui représente le numéro du client (Clé Étrangère)
        public int mCmdRestoID { get; set; }     // Donnée membre qui représente le numéro du restaurant (Clé Étrangère)
        public int mCmdTableID { get; set; }     // Donnée membre qui représente le numéro de la table (Clé Étrangère)
        public int mCmdServerID { get; set; }    // Donnée membre qui représente le numéro du server (Clé Étrangère)

     // public List<CRepas> mCmdTabRepas { get; set; }          // Donnée membre qui représente la liste des repas commandés
        public List<string> mCmdTabCommentRepas { get; set; }   // Donnée membre qui représente la liste des commentaires du client sur le repas
        public string mCmdCommentCommandes { get; set; }        // Donnée membre qui représente le commentaire du client concernant la commande
        public double mCmdPrixAvantTaxes { get; set; }          // Donnée membre qui représente le prix de la commande avant taxes
        public double mCmdPrixTotal { get; set; }               // Donnée membre qui représente la prix de la commande avec taxes
        public int mCmdStatusCommande { get; set; }             // Donnée membre qui représente le status de la commande (0 : Commande Passée, 1 : Commande Payée, 2 : Commande Annulée)
        public string mCmdDate { get; set; }                    // Donnée membre qui représente la date de la commande



    }
}