using RestoRapido.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace RestoRapido.Controllers
    {
        public class ApiLoginController : ApiController
        {
            public List<object> GetLogin(string login, string mdp)
            {
            string strCon = System.Web
                      .Configuration
                      .WebConfigurationManager
                      .ConnectionStrings["CRestoContext"].ConnectionString;
            string type = "";
                List<object> results = new List<object>();
                SqlConnection conn = new SqlConnection(strCon);
                SqlCommand checkuser = new SqlCommand("SELECT UtilisateurID,UtilisateurType,UtilisateurPrenom,UtilisateurNom,UtilisateurNomUsager,m_boBle,m_boLait,m_boOeuf,m_boArachide,m_boSoja,m_boFruitCoque,m_boPoisson,m_boSesame,m_boCrustace,m_boMollusque FROM Utilisateurs WHERE UtilisateurNomUsager = '" + login + "' AND UtilisateurMDP = '" + CEncryption.CalculateMD5Hash(mdp) + "'", conn);
                checkuser.Connection = conn;
                conn.Open();
                SqlDataReader dr = checkuser.ExecuteReader();
                

                if (dr.HasRows) //S'il l'utilisateur existe
                {
                    while (dr.Read()) //Ajouter les informations de l'usager 
                    {
                        type = dr.GetString(1);
                        results.Add(dr[0]);
                        results.Add(dr[1]);
                        results.Add(dr[2]);
                        results.Add(dr[3]);
                        results.Add(dr[4]);
                        results.Add(dr[5]);
                        results.Add(dr[6]);
                        results.Add(dr[7]);
                        results.Add(dr[8]);
                        results.Add(dr[9]);
                        results.Add(dr[10]);
                        results.Add(dr[11]);
                        results.Add(dr[12]);
                        results.Add(dr[13]);
                        results.Add(dr[14]);
                    }

                    if (type == "Client")   //Si le l'utilisateur est un client                                  
                        return results;
                   else return null; //Si l'utilisateur n'est pas un client
                }
                else return null; //S'il n'existe pas


            }
        }
    }


