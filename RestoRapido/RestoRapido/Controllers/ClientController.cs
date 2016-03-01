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
                SqlConnection conn = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\dbRestoRapidoV20.mdf;Initial Catalog=RestoRapido;Integrated Security=True");
                SqlCommand ajouteralerte = new SqlCommand("INSERT INTO CAlertes VALUES (" + Session["ID"] + ", " + Session["Table"] + ")");
                ajouteralerte.Connection = conn;
                conn.Open();
                ajouteralerte.ExecuteReader();
                return View("Index");
            }
            else
                return View("../Shared/Error");
        }



        public ActionResult SelectTable()
        {
                return View();
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
