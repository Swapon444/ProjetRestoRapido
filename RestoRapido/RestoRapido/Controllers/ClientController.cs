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
            if (@Session["Type"].ToString() == "Client")
                return View();
            else
                return View("../Shared/Error");
        }

        public ActionResult AppelerServeur()
        {
            if (@Session["Type"].ToString() == "Client")
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\dbRestoRapidoV22.mdf;Initial Catalog=RestoRapido;Integrated Security=True");
                conn.Open();

                SqlCommand regarderalerte = new SqlCommand("SELECT * FROM CAlertes WHERE UtilisateurID = " + Session["ID"]);
                regarderalerte.Connection = conn;
                SqlDataReader dr = regarderalerte.ExecuteReader();
                

                if (!dr.HasRows)
                {
                    conn.Close();
                    conn.Open();
                    SqlCommand ajouteralerte = new SqlCommand("INSERT INTO CAlertes VALUES (" + Session["ID"] + ", " + Session["Table"] + ")");
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
