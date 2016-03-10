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
        [HttpGet]
        public List<object> Modif(int id, string login, bool boBle, bool boLait, bool boOeuf, bool boArachide, bool boSoja, bool boFruitCoque, bool boPoisson, bool boSesame, bool boCrustace, bool boMollusque)
        {


            SqlConnection conn = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\dbRestoRapidoV26.mdf;Initial Catalog=RestoRapido;Integrated Security=True");
            SqlCommand checkuser = new SqlCommand("SELECT * FROM Utilisateurs WHERE UtilisateurNomUsager = '" + login + "'", conn);
            checkuser.Connection = conn;
            conn.Open();
            SqlDataReader dr = checkuser.ExecuteReader();

            List<object> results = new List<object>();

            if (dr.HasRows)
            {
                conn.Close();
                conn.Open();
                SqlCommand modifuser = new SqlCommand("UPDATE Utilisateurs SET m_boBle = '" + boBle + "', m_boLait = '" + boLait + "', m_boOeuf = '" + boOeuf + "', m_boArachide = '" + boArachide + "', m_boSoja = '" + boSoja + "', m_boFruitCoque = '" + boFruitCoque + "', m_boPoisson = '" + boPoisson + "', m_boSesame = '" + boSesame + "', m_boCrustace = '" + boCrustace + "', m_boMollusque = '" + boMollusque + "' WHERE UtilisateurID = " + id , conn);

                modifuser.Connection = conn;
                modifuser.ExecuteReader();

                results.Add(login);
                results.Add(boBle);
                results.Add(boLait);
                results.Add(boOeuf);
                results.Add(boArachide);
                results.Add(boSoja);
                results.Add(boFruitCoque);
                results.Add(boPoisson);
                results.Add(boSesame);
                results.Add(boCrustace);
                results.Add(boMollusque);



            }

            else {
                conn.Close();
                conn.Open();
                
                SqlCommand modifuser = new SqlCommand("UPDATE Utilisateurs SET UtilisateurNomUsager = '" + login + "', m_boBle = '" + boBle + "', m_boLait = '" + boLait + "', m_boOeuf = '" + boOeuf + "', m_boArachide = '" + boArachide + "', m_boSoja = '" + boSoja + "', m_boFruitCoque = '" + boFruitCoque + "', m_boPoisson = '" + boPoisson + "', m_boSesame = '" + boSesame + "', m_boCrustace = '" + boCrustace + "', m_boMollusque = '" + boMollusque + "' WHERE UtilisateurID = " + id, conn);

                modifuser.Connection = conn;
                modifuser.ExecuteReader();

                results.Add(login);
                results.Add(boBle);
                results.Add(boLait);
                results.Add(boOeuf);
                results.Add(boArachide);
                results.Add(boSoja);
                results.Add(boFruitCoque);
                results.Add(boPoisson);
                results.Add(boSesame);
                results.Add(boCrustace);
                results.Add(boMollusque);

                

            }
            conn.Close();
            return results;
        }
    }
}


