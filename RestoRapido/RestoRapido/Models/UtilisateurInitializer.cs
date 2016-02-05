using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestoRapido.Models
{
    public class UtilisateurInitializer : DropCreateDatabaseIfModelChanges<UtilisateurContext>
    {
        protected override void Seed(UtilisateurContext Context)
        {
            var Utilisateurs = new List<Utilisateur>
            {
                new Utilisateur { UtilisateurNom = "Monzerol" , UtilisateurNomUsager = "AntoineM", UtilisateurPrenom = "Antoine", UtilisateurType = "Administrateur" },
                new Utilisateur { UtilisateurNom = "Gratton" , UtilisateurNomUsager = "AlexandreG", UtilisateurPrenom = "Alexandre", UtilisateurType = "Serveur" },
                new Utilisateur { UtilisateurNom = "Verreault" , UtilisateurNomUsager = "FrancisV", UtilisateurPrenom = "Francis", UtilisateurType = "Gerant" },
                new Utilisateur { UtilisateurNom = "Otis" , UtilisateurNomUsager = "DaveO", UtilisateurPrenom = "Dave", UtilisateurType = "Client" }
            };

            foreach (var temp in Utilisateurs)
            {
                Context.Utilisateurs.Add(temp);
            }


            Context.SaveChanges();
        }
    }
}