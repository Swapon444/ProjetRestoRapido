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
                new Utilisateur { UtilisateurNom = "Gratton" , UtilisateurNomUsager = "AlexandreG", UtilisateurPrenom = "Alexandre", UtilisateurType = "Serveur", UtilisateurMDP = "1234"},
                new Utilisateur { UtilisateurNom = "Verreault" , UtilisateurNomUsager = "FrancisV", UtilisateurPrenom = "Francis", UtilisateurType = "Gerant" ,  UtilisateurMDP = "1234" },
                new Utilisateur { UtilisateurNom = "Otis" , UtilisateurNomUsager = "DaveO", UtilisateurPrenom = "Dave", UtilisateurType = "Client" ,  UtilisateurMDP = "1234"},
                new Utilisateur { UtilisateurNom = "Deslandes" , UtilisateurNomUsager = "MarcD", UtilisateurPrenom = "Marc", UtilisateurType = "Client" ,  UtilisateurMDP = "1234"},
                new Utilisateur { UtilisateurNom = "Beaudoin" , UtilisateurNomUsager = "KevinB", UtilisateurPrenom = "Kevin", UtilisateurType = "Serveur" ,  UtilisateurMDP = "1234" },
            };

            foreach (var temp in Utilisateurs)
            {
                Context.Utilisateurs.Add(temp);
            }

            Context.SaveChanges();

            var Tables = new List<CTable>
            {
                new CTable {i_TableNum = 1, CRestoID = 1 },
                new CTable {i_TableNum = 2, CRestoID = 1 },
                new CTable {i_TableNum = 3, CRestoID = 1 },
                new CTable {i_TableNum = 4, CRestoID = 1 },
                new CTable {i_TableNum = 5, CRestoID = 1 },
                new CTable {i_TableNum = 6, CRestoID = 1 },
                new CTable {i_TableNum = 7, CRestoID = 1 },
                new CTable {i_TableNum = 8, CRestoID = 1 },

            };

            foreach (var temp in Tables)
            {
                Context.Tables.Add(temp);
            }

            Context.SaveChanges();

            var UtilisateursTables = new List<CTableUtilisateurs>
            {
                //Serveurs
                new CTableUtilisateurs { CTableID = Tables[0].CTableID, UtilisateurID = Utilisateurs[1].UtilisateurID },
                new CTableUtilisateurs { CTableID = Tables[1].CTableID, UtilisateurID = Utilisateurs[1].UtilisateurID },
                new CTableUtilisateurs { CTableID = Tables[2].CTableID, UtilisateurID = Utilisateurs[1].UtilisateurID },
                new CTableUtilisateurs { CTableID = Tables[3].CTableID, UtilisateurID = Utilisateurs[1].UtilisateurID },
                new CTableUtilisateurs { CTableID = Tables[4].CTableID, UtilisateurID = Utilisateurs[5].UtilisateurID },
                new CTableUtilisateurs { CTableID = Tables[5].CTableID, UtilisateurID = Utilisateurs[5].UtilisateurID },
                new CTableUtilisateurs { CTableID = Tables[6].CTableID, UtilisateurID = Utilisateurs[5].UtilisateurID },
                new CTableUtilisateurs { CTableID = Tables[7].CTableID, UtilisateurID = Utilisateurs[5].UtilisateurID },

                //Clients
                new CTableUtilisateurs { CTableID = Tables[1].CTableID, UtilisateurID = Utilisateurs[3].UtilisateurID },
                new CTableUtilisateurs { CTableID = Tables[7].CTableID, UtilisateurID = Utilisateurs[4].UtilisateurID },

            };

            foreach (var temp in UtilisateursTables)
            {
                Context.TableUtilisateurs.Add(temp);
            }



            Context.SaveChanges();
            
        } 
    } 
}