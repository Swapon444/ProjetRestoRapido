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
        public class ApiModifierController : ApiController
        {
            public List<object> Modif(int id, string login,bool boBle,bool boLait, bool boOeuf,bool boArachide, bool boSoja, bool boFruitCoque, bool boPoisson, bool boSesame, bool boCrustace, bool boMollusque)
            {
       
                List<object> results = new List<object>();

                SqlConnection conn = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\dbRestoRapidoV25.mdf;Initial Catalog=RestoRapido;Integrated Security=True");
                SqlCommand modifuser = new SqlCommand("SELECT UtilisateurID,UtilisateurType,UtilisateurPrenom,UtilisateurNom,UtilisateurNomUsager,m_boBle,m_boLait,m_boOeuf,m_boArachide,m_boSoja,m_boFruitCoque,m_boPoisson,m_boSesame,m_boCrustace,m_boMollusque FROM Utilisateurs WHERE UtilisateurNomUsager = '" + login + "' AND UtilisateurMDP = '" + CEncryption.CalculateMD5Hash(mdp) + "'", conn);

                modifuser.Connection = conn;
                conn.Open();
                SqlDataReader dr = modifuser.ExecuteReader();

            return results;

            }
        }
    }


