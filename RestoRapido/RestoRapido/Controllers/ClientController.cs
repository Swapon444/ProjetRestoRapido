using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestoRapido.Models;
using System.Data.SqlClient;

namespace RestoRapido.Controllers
{
    public class ClientController : Controller
    {
        private CRestoContext db = new CRestoContext();

        public ActionResult Index()
        {
            if (@Session["Type"] != null)
            {
                if (@Session["Type"].ToString() == "Client")
                    return View();
                return View("../Shared/Error");
            }
            else
                return View("../Shared/Error");
        }

        public ActionResult AppelerServeur()
        {
            //Objectif : Notifier le serveur par la table utilisée par le client courant
            if (@Session["Type"] == null)
                return View("../Shared/Error");

            if (@Session["Type"].ToString() == "Client")
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\dbRestoRapidoV25.mdf;Initial Catalog=RestoRapido;Integrated Security=True");
                conn.Open();

                //Regarder tout d'abord si le server n'a pas déjà été alerté par le même client
                SqlCommand regarderalerte = new SqlCommand("SELECT * FROM CAlertes WHERE UtilisateurID = " + Session["ID"]);
                regarderalerte.Connection = conn;

                SqlDataReader dr = regarderalerte.ExecuteReader();

                int idUser = Convert.ToInt32(Session["ID"]);

                var temp = from s in db.Commandes
                           where s.UtilisateurID == idUser && s.mCmdStatusCommande == 0
                           select s.CTableID;


                if (temp.Count() < 1) //Si le client n'a pas passé une commande 
                    return View("Index");
                
                int idTable = temp.First(); //Affecter la table au client

                if (!dr.HasRows) //Si le serveur n'a pas été notifié, ajouter l'alerte dans la base de donnée 
                {
                    conn.Close();
                    conn.Open();
                    SqlCommand ajouteralerte = new SqlCommand("INSERT INTO CAlertes VALUES (" + Session["ID"] + ", " + idTable + ")");
                    ajouteralerte.Connection = conn;
                    ajouteralerte.ExecuteReader();
                }
                conn.Close();
                return View("Index");
            }
            else
                return View("../Shared/Error");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
