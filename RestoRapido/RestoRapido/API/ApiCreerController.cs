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
    public class ApiCreerController : ApiController
    {
  
        public int Creer(string login, string mdp, string prenom, string nom, bool boBle, bool boLait, bool boOeuf, bool boArachide, bool boSoja, bool boFruitCoque, bool boPoisson, bool boSesame, bool boCrustace, bool boMollusque)
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\dbRestoRapidoV26.mdf;Initial Catalog=RestoRapido;Integrated Security=True");
            SqlCommand checkuser = new SqlCommand("SELECT * FROM Utilisateurs WHERE UtilisateurNomUsager = '" + login + "'", conn);
            checkuser.Connection = conn;
            conn.Open();
            SqlDataReader dr = checkuser.ExecuteReader();
            conn.Close();

            if (!dr.HasRows)
            {
            
                SqlCommand adduser = new SqlCommand("INSERT INTO Utilisateurs VALUES (" + mdp + "," + login + "," + nom + "," + prenom + ", Client ," + boBle + "," + boLait + "," + boOeuf + "," + boArachide + "," + boSoja + "," + boFruitCoque + "," + boPoisson + "," + boSesame + "," + boCrustace + "," + boMollusque + ")", conn);
                adduser.Connection = conn;
                conn.Open();
                adduser.ExecuteReader();

                return 1;
            }
            return 0;
        }
    }
}


