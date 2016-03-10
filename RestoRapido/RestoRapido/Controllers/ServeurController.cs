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
            if (@Session["Type"] != null)
                if (@Session["Type"].ToString() == "Serveur")
                    return View();

            return View("../Home/Index");
        }

        public ActionResult Alertes()
        {
            //Objectif : Afficher les alertes d'un serveur

            if (@Session["Type"] != null)
                if (@Session["Type"].ToString() == "Serveur")
                {
                    //Aller chercher toutes les alertes du serveur
                    SqlConnection conn = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\dbRestoRapidoV26.mdf;Initial Catalog=RestoRapido;Integrated Security=True");
                    SqlCommand alertes = new SqlCommand("SELECT i_TableNum FROM CTables INNER JOIN CAlertes ON CTables.CTableID = CAlertes.CTableID INNER JOIN UtilisateurCTables ON CAlertes.CTableID = UtilisateurCTables.CTable_CTableID WHERE UtilisateurCTables.Utilisateur_UtilisateurID = " + Session["ID"], conn);
                    alertes.Connection = conn;
                    conn.Open();
                    SqlDataReader dr = alertes.ExecuteReader();

                    List<string> Tables = new List<string>();

                    while (dr.Read()) //Mettre dans la liste toutes les tables qui ont appelé le serveur
                        Tables.Add("Table #" + dr.GetInt32(0).ToString());


                    return View(Tables);
                }

            return View("../Home/Index");
        }

        public ActionResult Supprimer()
        {
            //Objectif : Supprimer les alertes d'un serveur
            if (@Session["Type"] != null)
                if (@Session["Type"].ToString() == "Serveur")
                {
                    //Supprimer toutes les alertes qui ont le même UtilisateurID que l'ID du serveur
                    SqlConnection conn = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\dbRestoRapidoV26.mdf;Initial Catalog=RestoRapido;Integrated Security=True");
                    SqlCommand alertes = new SqlCommand("DELETE CAlertes FROM CAlertes INNER JOIN UtilisateurCTables on CAlertes.CTableID = UtilisateurCTables.CTable_CTableID WHERE UtilisateurCTables.Utilisateur_UtilisateurID = " + Session["ID"], conn);

                    alertes.Connection = conn;
                    conn.Open();
                    alertes.ExecuteReader();


                    return View("Index");
                }

            return View("../Home/Index");
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
            if (@Session["Type"] != null)
                if (@Session["Type"].ToString() == "Serveur")
                {
                    int ID = Convert.ToInt32(Session["ID"]);

                    Utilisateur serveur = db.Utilisateurs
                        .Include(i => i.Tables)
                        .Where(i => i.UtilisateurID == ID)
                        .Single();

                    PopulateAssignedTableData(serveur);
                    return View(serveur);
                }

            return View("../Home/Index");
        }

        public ActionResult SaveSelectTable(string[] selectedTables)
        {
            if (@Session["Type"] != null)
                if (@Session["Type"].ToString() == "Serveur")
                {
                    int ID = Convert.ToInt32(Session["ID"]);

                    Utilisateur serveurToUpdate = db.Utilisateurs
                        .Include(i => i.Tables)
                        .Where(i => i.UtilisateurID == ID)
                        .Single();

                    UpdateServeurTables(selectedTables, serveurToUpdate);

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

            return View("../Home/Index");
        }

        private void UpdateServeurTables(string[] selectedTables, Utilisateur serveurToUpdate)
        {
            if (selectedTables == null)
            {
                serveurToUpdate.Tables = new List<CTable>();
                return;
            }


           

            int ServeurID = Convert.ToInt32(Session["ID"]);
            var selectedTablesHS = new HashSet<string>(selectedTables);
            var serveurTables = new HashSet<int>
                (serveurToUpdate.Tables.Select(c => c.CTableID));


            foreach (var table in db.Tables)
            {

                if (selectedTablesHS.Contains(table.CTableID.ToString()))
                {

                    if (!serveurTables.Contains(table.CTableID))
                    {
                        SqlConnection conn = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\dbRestoRapidoV26.mdf;Initial Catalog=RestoRapido;Integrated Security=True");
                        SqlCommand ajouterTableServeur = new SqlCommand("INSERT INTO UtilisateurCTables VALUES (" + ServeurID + "," + table.CTableID + ")", conn);

                        ajouterTableServeur.Connection = conn;
                        conn.Open();

                        ajouterTableServeur.ExecuteReader();

                        conn.Close();

                    }
                }
                else
                {
                    if (serveurTables.Contains(table.CTableID))
                    {
                        SqlConnection conn = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\dbRestoRapidoV26.mdf;Initial Catalog=RestoRapido;Integrated Security=True");
                        SqlCommand supprimerTableServeur = new SqlCommand("DELETE UtilisateurCTables FROM UtilisateurCTables WHERE UtilisateurCTables.Utilisateur_UtilisateurID = " + ServeurID + " AND UtilisateurCTables.CTable_CTableID = " + table.CTableID, conn);

                        supprimerTableServeur.Connection = conn;
                        conn.Open();
                        supprimerTableServeur.ExecuteReader();

                        conn.Close();
                    }
                }
            }
            db.SaveChanges();
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
