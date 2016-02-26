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
    public class ServeurController : Controller
    {
        private CRestoContext db = new CRestoContext();

        public ActionResult Index()
        {
            if (@Session["Type"].ToString() == "Serveur")
                return View();
            else
                return View("../Shared/Error");
        }

        public ActionResult Alertes()
        {
            if (@Session["Type"].ToString() == "Serveur")
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\dbRestoRapidoV6.mdf;Initial Catalog=RestoRapido;Integrated Security=True");
                SqlCommand alertes = new SqlCommand("SELECT i_TableNum FROM CTables INNER JOIN CAlertes ON CTables.CTableID = CAlertes.CTableID INNER JOIN CTableUtilisateurs ON CAlertes.CTableID = CTableUtilisateurs.CTableID WHERE CTableUtilisateurs.UtilisateurID = " + Session["ID"], conn);
                alertes.Connection = conn;
                conn.Open();
                SqlDataReader dr = alertes.ExecuteReader();

                List<string> Tables = new List<string>();

                while (dr.Read())
                    Tables.Add("Table #" + dr.GetInt32(0).ToString());


                return View(Tables);
            }
            else
                return View("../Shared/Error");
        }

        public ActionResult Supprimer()
        {
            if (@Session["Type"].ToString() == "Serveur")
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\dbRestoRapidoV6.mdf;Initial Catalog=RestoRapido;Integrated Security=True");
                SqlCommand alertes = new SqlCommand("DELETE CAlertes FROM CAlertes INNER JOIN CTableUtilisateurs on CAlertes.CTableID = CTableUtilisateurs.CTableID WHERE CTableUtilisateurs.UtilisateurID = " + Session["ID"], conn);

                alertes.Connection = conn;
                conn.Open();
                alertes.ExecuteReader();




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
