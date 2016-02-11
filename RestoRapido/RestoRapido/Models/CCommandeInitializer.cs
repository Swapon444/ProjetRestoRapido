using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestoRapido.Models
{
    public class CCommandeInitializer : DropCreateDatabaseIfModelChanges<CCommandeContext>
    {

        protected override void Seed(CCommandeContext Context)
        {

            var Commandes = new List<CCommande>
            {
                new CCommande { mCmdClientID = 1 , 
                                mCmdRestoID = 1, 
                                mCmdTableID = 1, 
                                mCmdServerID = 1, 
                             // mCmdTabRepas = null,
                                mCmdTabCommentRepas = null,
                                mCmdCommentCommandes = "Commande Initializer A",
                                mCmdPrixAvantTaxes = 0.00,
                                mCmdPrixTotal = 0.00,
                                mCmdStatusCommande = 0,
                                mCmdDate = "01-01-2016" 
                },

                new CCommande { mCmdClientID = 1, 
                                mCmdRestoID = 1, 
                                mCmdTableID = 1, 
                                mCmdServerID = 1, 
                             // mCmdTabRepas = null,
                                mCmdTabCommentRepas = null,
                                mCmdCommentCommandes = "Commande Initializer B",
                                mCmdPrixAvantTaxes = 0.00,
                                mCmdPrixTotal = 0.00,
                                mCmdStatusCommande = 1,
                                mCmdDate = "01-01-2016"
                }

            };

            foreach (var temp in Commandes)
            {
                Context.mCommandes.Add(temp);
            }


            Context.SaveChanges();
        }

    }
}