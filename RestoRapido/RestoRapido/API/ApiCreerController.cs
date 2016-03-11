using RestoRapido.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace RestoRapido.Controllers
{
    public class ApiCreerController : ApiController
    {
        [System.Web.Http.HttpGet]
        public int Creer(string login, string mdp, string prenom, string nom, bool boBle, bool boLait, bool boOeuf, bool boArachide, bool boSoja, bool boFruitCoque, bool boPoisson, bool boSesame, bool boCrustace, bool boMollusque)
        {
            string strCon = System.Web
                      .Configuration
                      .WebConfigurationManager
                      .ConnectionStrings["CRestoContext"].ConnectionString;
            SqlConnection conn = new SqlConnection(strCon);
            SqlCommand checkuser = new SqlCommand("SELECT * FROM Utilisateurs WHERE UtilisateurNomUsager = '" + login + "'", conn);
            checkuser.Connection = conn;
            conn.Open();
            SqlDataReader dr = checkuser.ExecuteReader();
            

            if (!dr.HasRows)
            {
                conn.Close();

                SqlCommand adduser = new SqlCommand("INSERT INTO Utilisateurs VALUES ('" + CEncryption.CalculateMD5Hash(mdp) + "','" + login + "','" + nom + "','" + prenom + "','Client','" + boBle + "','" + boLait + "','" + boOeuf + "','" + boArachide + "','" + boSoja + "','" + boFruitCoque + "','" + boPoisson + "','" + boSesame + "','" + boCrustace + "','" + boMollusque + "')", conn);
                adduser.Connection = conn;
                conn.Open();
                adduser.ExecuteReader();

                return 1;
            }
            return 0;
        }
    }
}


