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
using RestoRapido.ViewModels;

namespace RestoRapido.Controllers
{
    public class ServeurController : Controller
    {
        private CRestoContext db = new CRestoContext();

        public ActionResult Index()
        {
            if (@Session["Type"] == null)
                return View("../Shared/Error");

            else if (@Session["Type"].ToString() == "Serveur")
                return View();
            else
                return View("../Shared/Error");
        }

        public ActionResult Alertes()
        {
            if (@Session["Type"] == null)
                return View("../Shared/Error");

           else if (@Session["Type"].ToString() == "Serveur")
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\dbRestoRapidoV22.mdf;Initial Catalog=RestoRapido;Integrated Security=True");
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
            if (@Session["Type"] == null)
                return View("../Shared/Error");

          else if (@Session["Type"].ToString() == "Serveur")
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\dbRestoRapidoV22.mdf;Initial Catalog=RestoRapido;Integrated Security=True");
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

        public ActionResult SelectTable()
        {
            int ID = Convert.ToInt32(Session["ID"]);

            Utilisateur serveur = db.Utilisateurs
                .Include(i => i.Tables)
                .Where(i => i.UtilisateurID == ID)
                .Single();

            PopulateAssignedTableData(serveur);
            return View(serveur);
        }

        private void PopulateAssignedTableData(Utilisateur serveur)
        {
            int RestoID = Convert.ToInt32(Session["RestoID"]);
            var allTables = db.Tables
                .Where(i => i.CRestoID == RestoID);
            var serveurTables = new HashSet<int>(serveur.Tables.Select(c => c.CTableID));
            var viewModel = new List<AssignedTableData>();
            foreach (var table in allTables)
            {
                viewModel.Add(new AssignedTableData
                {
                    CTableID = table.CTableID,
                    NumTable = table.i_TableNum,
                    Assigned = serveurTables.Contains(table.CTableID)
                });
            }
            ViewBag.Tables = viewModel;
        }

    }
}
