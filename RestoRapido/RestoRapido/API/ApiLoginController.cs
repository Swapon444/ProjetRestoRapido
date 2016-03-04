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
            public int GetLogin(string login, string mdp)
            {
                string type = "";

                SqlConnection conn = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\dbRestoRapidoV22.mdf;Initial Catalog=RestoRapido;Integrated Security=True");
                SqlCommand checkuser = new SqlCommand("SELECT UtilisateurType,UtilisateurPrenom, UtilisateurID FROM Utilisateurs WHERE UtilisateurNomUsager = '" + login + "' AND UtilisateurMDP = '" + CEncryption.CalculateMD5Hash(mdp) + "'", conn);
                checkuser.Connection = conn;
                conn.Open();
                SqlDataReader dr = checkuser.ExecuteReader();

                if (dr.HasRows) //S'il l'utilisateur existe
                {
                    while (dr.Read())
                        type = dr.GetString(0);

                    if (type == "Client")
                        return 1; //Si le l'utilisateur est un client
                    else return 0; //Si l'utilisateur n'est pas un client
                }
                else return 0; //S'il ne fonctionne pas


            }
        }
    }


