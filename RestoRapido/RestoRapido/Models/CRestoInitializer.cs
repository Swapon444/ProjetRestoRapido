using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestoRapido.Models
{
    public class CRestoInitializer : DropCreateDatabaseIfModelChanges<CRestoContext>
    {
        protected override void Seed(CRestoContext Context)
        {
            var Utilisateurs = new List<Utilisateur>
            {
                new Utilisateur { UtilisateurNom = "Monzerol" , UtilisateurNomUsager = "AntoineM", UtilisateurPrenom = "Antoine", UtilisateurType = "Administrateur", UtilisateurMDP = "1234" },
                new Utilisateur { UtilisateurNom = "Gratton" , UtilisateurNomUsager = "AlexandreG", UtilisateurPrenom = "Alexandre", UtilisateurType = "Serveur", UtilisateurMDP = "1234"  },
                new Utilisateur { UtilisateurNom = "Verreault" , UtilisateurNomUsager = "FrancisV", UtilisateurPrenom = "Francis", UtilisateurType = "Gerant" ,  UtilisateurMDP = "1234" },
                new Utilisateur { UtilisateurNom = "Otis" , UtilisateurNomUsager = "DaveO", UtilisateurPrenom = "Dave", UtilisateurType = "Client" ,  UtilisateurMDP = "1234" }
            };

            foreach (var temp in Utilisateurs)
            {
                Context.Utilisateurs.Add(temp);
            }


            Context.SaveChanges();
        }
    }
}