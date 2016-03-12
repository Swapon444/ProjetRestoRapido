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
            //---------------------------------------------------------------------------------------------------------
            // UTILISATEURS
            var Utilisateurs = new List<Utilisateur>
            {
                new Utilisateur { UtilisateurID = 1, UtilisateurNom = "Monzerol" , UtilisateurNomUsager = "AntoineM", UtilisateurPrenom = "Antoine", UtilisateurType = "Administrateur", UtilisateurMDP = "81dc9bdb52d04dc20036dbd8313ed055" },
                new Utilisateur { UtilisateurID = 2, UtilisateurNom = "Gratton" , UtilisateurNomUsager = "AlexandreG", UtilisateurPrenom = "Alexandre", UtilisateurType = "Serveur", UtilisateurMDP = "81dc9bdb52d04dc20036dbd8313ed055"},
                new Utilisateur { UtilisateurID = 3, UtilisateurNom = "Verreault" , UtilisateurNomUsager = "FrancisV", UtilisateurPrenom = "Francis", UtilisateurType = "Gerant" ,  UtilisateurMDP = "81dc9bdb52d04dc20036dbd8313ed055" },
                new Utilisateur { UtilisateurID = 4, UtilisateurNom = "Otis" , UtilisateurNomUsager = "DaveO", UtilisateurPrenom = "Dave", UtilisateurType = "Client" ,  UtilisateurMDP = "81dc9bdb52d04dc20036dbd8313ed055"},
                new Utilisateur { UtilisateurID = 5, UtilisateurNom = "Deslandes" , UtilisateurNomUsager = "MarcD", UtilisateurPrenom = "Marc", UtilisateurType = "Client" ,  UtilisateurMDP = "81dc9bdb52d04dc20036dbd8313ed055"},
                new Utilisateur { UtilisateurID = 6, UtilisateurNom = "Beaudoin" , UtilisateurNomUsager = "KevinB", UtilisateurPrenom = "Kevin", UtilisateurType = "Serveur" ,  UtilisateurMDP = "81dc9bdb52d04dc20036dbd8313ed055" }
            };

            foreach (var temp in Utilisateurs)
            {
                Context.Utilisateurs.Add(temp);
            }

            Context.SaveChanges();

            //---------------------------------------------------------------------------------------------------------
            // RESTAURANTS
            var Restos = new List<CResto>
            {
                new CResto { CRestoID = 1, resNom = "RestoRapidoP1", resNoCiv = "1234", resRue = "MontRoyal", resPostal="H2K 3A5"},
                new CResto { CRestoID = 2, resNom = "RestoRapidoP2", resNoCiv = "888", resRue = "Firestone", resPostal="A1A 1A1"}
            };

            foreach (var tempB in Restos)
            {
                Context.Resto.Add(tempB);
            }

            Context.SaveChanges();

            //---------------------------------------------------------------------------------------------------------
            // TABLES
            var Tables = new List<CTable>
            {
                /*
                new CTable {CTableID = 1, i_TableNum = 1, CRestoID = 1 },
                new CTable {CTableID = 2, i_TableNum = 2, CRestoID = 1 },
                new CTable {CTableID = 3, i_TableNum = 3, CRestoID = 1 },
                new CTable {CTableID = 4, i_TableNum = 4, CRestoID = 1 },
                new CTable {CTableID = 5, i_TableNum = 5, CRestoID = 1 },
                new CTable {CTableID = 6, i_TableNum = 6, CRestoID = 1 },
                new CTable {CTableID = 7, i_TableNum = 7, CRestoID = 1 },
                new CTable {CTableID = 8, i_TableNum = 8, CRestoID = 1 },
                new CTable {CTableID = 9, i_TableNum = 1, CRestoID = 2 },
                new CTable {CTableID = 10, i_TableNum = 2, CRestoID = 2 },
                new CTable {CTableID = 11, i_TableNum = 3, CRestoID = 2 },
                new CTable {CTableID = 12, i_TableNum = 4, CRestoID = 2 },
                new CTable {CTableID = 13, i_TableNum = 5, CRestoID = 2 },
                new CTable {CTableID = 14, i_TableNum = 6, CRestoID = 2 },
                new CTable {CTableID = 15, i_TableNum = 7, CRestoID = 2 },
                new CTable {CTableID = 16, i_TableNum = 8, CRestoID = 2 }
                  */
            };

            foreach (var tempC in Tables)
            {
                Context.Tables.Add(tempC);
            }

            Context.SaveChanges();

            //---------------------------------------------------------------------------------------------------------
            // REPAS
            var Repas = new List<CRepas>
            {
                new CRepas { m_iRepasId = 1, m_strNom = "Poutine", m_iPrix = Convert.ToDecimal(7.50), m_strDescription = "Frites, Fromage, Sauce", m_boLait = true},
                new CRepas { m_iRepasId = 2, m_strNom = "Coke", m_iPrix = Convert.ToDecimal(1.50), m_strDescription = "0 Calories"},
                new CRepas { m_iRepasId = 3, m_strNom = "Hamburger", m_iPrix = Convert.ToDecimal(4.99), m_strDescription = "All Dressed Mon Ami", m_boSesame = true},
                new CRepas { m_iRepasId = 4, m_strNom = "HotDog", m_iPrix = Convert.ToDecimal(2.99), m_strDescription = "Delicious"},
                new CRepas { m_iRepasId = 5, m_strNom = "Pizza", m_iPrix = Convert.ToDecimal(12.99), m_strDescription = "Medium Pepperoni Fromage"}
            };

            foreach (var tempZ in Repas)
            {
                Context.Repas.Add(tempZ);
            }

            Context.SaveChanges();

            List<CRepas> lstRepas = new List<CRepas>();
            lstRepas.Add(Repas[0]);
            lstRepas.Add(Repas[1]);
            lstRepas.Add(Repas[2]);

            List<string> lstComment = new List<string> { "Papa", "Maman", "Bebe" };

            //---------------------------------------------------------------------------------------------------------
            // MENUS
            var Menus = new List<CMenu>
            {
                new CMenu { m_iMenuId = 1, m_strNom = "Menu fin de semaine", m_DateDebut = DateTime.Parse("2016-01-01"), m_DateFin = DateTime.Parse("2016-02-01"), m_Repas = new List<CRepas>() },
                new CMenu { m_iMenuId = 2, m_strNom = "Menu semaine", m_DateDebut = DateTime.Parse("2016-01-01"), m_DateFin = DateTime.Parse("2016-12-01"), m_Repas = new List<CRepas>() },
                new CMenu { m_iMenuId = 3, m_strNom = "Menu spécial", m_DateDebut = DateTime.Parse("2016-05-01"), m_DateFin = DateTime.Parse("2016-05-10"), m_Repas = new List<CRepas>() }
            };

            foreach (var menu in Menus)
            {
                Context.Menus.Add(menu);
            }

            Context.SaveChanges();

            //---------------------------------------------------------------------------------------------------------
            // TABLE_UTILISATEUR
    //        var UtilisateursTables = new List<CTableUtilisateurs>
           // {
                //Serveurs
            //    new CTableUtilisateurs { CTableID = 1, UtilisateurID = 2 },
            //    new CTableUtilisateurs { CTableID = 2, UtilisateurID = 2 },
             //   new CTableUtilisateurs { CTableID = 3, UtilisateurID = 2 },
            //    new CTableUtilisateurs { CTableID = 4, UtilisateurID = 2 },
              //  new CTableUtilisateurs { CTableID = 5, UtilisateurID = 6 },
              //  new CTableUtilisateurs { CTableID = 6, UtilisateurID = 6 },
              //  new CTableUtilisateurs { CTableID = 7, UtilisateurID = 6 },
              //  new CTableUtilisateurs { CTableID = 8, UtilisateurID = 6 },

                //Clients
              //  new CTableUtilisateurs { CTableID = 1, UtilisateurID = 4 },
              //  new CTableUtilisateurs { CTableID = 2, UtilisateurID = 5 }
     /*       };

            foreach (var temp in UtilisateursTables)
            {
                Context.TableUtilisateurs.Add(temp);
            }

            Context.SaveChanges();
            */
            //---------------------------------------------------------------------------------------------------------
            // COMMANDES
     /*       var Commandes = new List<CCommande>
            {
                //new CCommande { mCmdID = 1, mCmdStatusCommande = 0, CRestoID = 1, CTableID = 1,  UtilisateurID = 4, mCmdColletionRepas = lstRepas, mCmdTabCommentRepas = lstComment, mCmdCommentCommandes = "Coucou les coucous", mCmdPrixAvantTaxes = 100, mCmdPrixTotal = 100}
                new CCommande { mCmdID = 1, mCmdStatusCommande = 0, CRestoID = 1,   UtilisateurID = 4, mCmdColletionRepas = lstRepas, mCmdTabCommentRepas = lstComment, mCmdCommentCommandes = "Coucou les coucous", mCmdPrixAvantTaxes = 100, mCmdPrixTotal = 100, mCmdDate = "2016-02-29"},
                new CCommande { mCmdID = 2, mCmdStatusCommande = 1, CRestoID = 1,   UtilisateurID = 4, mCmdColletionRepas = lstRepas, mCmdTabCommentRepas = lstComment, mCmdCommentCommandes = "J'aime les patates", mCmdPrixAvantTaxes = 100, mCmdPrixTotal = 100,  mCmdDate = "2016-02-28"},
                new CCommande { mCmdID = 3, mCmdStatusCommande = 1, CRestoID = 1,   UtilisateurID = 4, mCmdColletionRepas = lstRepas, mCmdTabCommentRepas = lstComment, mCmdCommentCommandes = "Vive les chats", mCmdPrixAvantTaxes = 50, mCmdPrixTotal = 50,  mCmdDate = "2016-02-26"},
                new CCommande { mCmdID = 4, mCmdStatusCommande = 2, CRestoID = 1,   UtilisateurID = 4, mCmdColletionRepas = lstRepas, mCmdTabCommentRepas = lstComment, mCmdCommentCommandes = "Patati Patata", mCmdPrixAvantTaxes = 0, mCmdPrixTotal = 0,  mCmdDate = "2016-02-26"}
            };

            foreach (var tempE in Commandes)
            {
                Context.Commandes.Add(tempE);
            }

            Context.SaveChanges();  */
        } 
    } 
}