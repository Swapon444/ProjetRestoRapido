using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestoRapido.Models;
using RestoRapido.ViewModels;
using System.Data.SqlClient;

namespace RestoRapido.Controllers
{
    public class CommandesController : Controller
    {
        private CRestoContext db = new CRestoContext();

        // GET: Commandes
        public ActionResult Index()
        {
            ViewBag.SiPaye = true;
            ViewBag.cmdAPayer = null;


            if (@Session["Connexion"] != null)
            {
                ViewBag.Type = Session["Type"].ToString();

                if ((bool)@Session["Connexion"] == false)
                {
                    return RedirectToAction("Login", "Account");
                }

                else if (@Session["Type"].ToString() == "Client")
                {

                    int i = Convert.ToInt32(@Session["ID"]);

                    var commandes = from s in db.Commandes
                                    where s.UtilisateurID == i
                                    select s;

                    commandes = commandes.Include(c => c.mCmdResto).Include(c => c.mCmdTable).Include(c => c.mUtilisateurClient);

                    foreach (var k in commandes)
                    {
                        if (k.mCmdStatusCommande == 0)
                        {
                            ViewBag.SiPaye = false;
                            ViewBag.cmdAPayer = k.mCmdID;
                        }
                    }

                    return View(commandes.ToList());
                }

                else if (@Session["Type"].ToString() == "Serveur")
                {
                    return RedirectToAction("IndexServeur");
                }

                var cmd = from s in db.Commandes
                          select s;

                cmd = cmd.Include(c => c.mCmdResto).Include(c => c.mCmdTable).Include(c => c.mUtilisateurClient);

                return View(cmd.ToList());

            }

            else
                return View("../Home/Index");

        }

        public ActionResult CommandeRapport(FormCollection collection)
        {
            var DateString = collection.Get("DateRapport");
            if (@Session["Connexion"] != null)
            {
                if ((bool)@Session["Connexion"] == false)
                {
                    return RedirectToAction("Login", "Account");
                }

                else
                {
                    DateTime DateRapport = DateTime.Parse(DateString);

                    DateTime tempo = DateRapport.AddDays(1);

                    var Cmd = from s in db.Commandes
                              where s.mCmdDate >= DateRapport && s.mCmdDate < tempo && s.mCmdStatusCommande == 1
                              select s;
                    return View(Cmd.ToList());
                }
            }
            else
                return RedirectToAction("Login", "Account");
        }



        // GET: Commandes
        public ActionResult IndexServeur()
        {
            string strCon = System.Web
                      .Configuration
                      .WebConfigurationManager
                      .ConnectionStrings["CRestoContext"].ConnectionString;
            if (@Session["Connexion"] != null)
            {
                if ((bool)@Session["Connexion"] == false)
                {
                    return RedirectToAction("Login", "Account");
                }

                else
                {
                    int iResto = Convert.ToInt32(Session["RestoID"]);

                    var commandes = from s in db.Commandes
                                    where s.mCmdStatusCommande == 0 && s.CRestoID == iResto
                                    select s;

                    commandes = commandes.Include(c => c.mCmdResto).Include(c => c.mCmdTable).Include(c => c.mUtilisateurClient);

                    SqlConnection conn = new SqlConnection(strCon);
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT CTables.i_TableNum FROM CCommandes INNER JOIN CTables ON CCommandes.CTableID = CTables.CTableID INNER JOIN UtilisateurCTables ON CTables.CTableID = UtilisateurCTables.CTable_CTableID INNER JOIN Utilisateurs ON UtilisateurCTables.Utilisateur_UtilisateurID = Utilisateurs.UtilisateurID WHERE CCommandes.mCmdStatusCommande = 0 AND UtilisateurCTables.Utilisateur_UtilisateurID = " + Session["ID"] + " AND CCommandes.CRestoID = " + Session["RestoID"], conn);
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    List<CCommande> lstCommandes = new List<CCommande>();

                    while (dr.Read())
                    {
                        foreach (var t in commandes)
                        {
                            if (t.mCmdTable.i_TableNum == dr.GetInt32(0))
                                lstCommandes.Add(t);
                        }
                    }

                    return View(lstCommandes);
                }
            }

            else
                return RedirectToAction("Login", "Account");

        }


        // GET: Commandes
        public ActionResult IndexAGS()
        {
            ViewBag.SiPaye = true;
            ViewBag.cmdAPayer = null;

            if (@Session["Connexion"] != null)
            {
                if ((bool)@Session["Connexion"] == false)
                {
                    return RedirectToAction("Login", "Account");
                }

                else
                {
                    int i = Convert.ToInt32(@Session["ID"]);

                    var commandes = from s in db.Commandes
                                    where s.UtilisateurID == i
                                    select s;

                    commandes = commandes.Include(c => c.mCmdResto).Include(c => c.mCmdTable).Include(c => c.mUtilisateurClient);

                    foreach (var k in commandes)
                    {
                        if (k.mCmdStatusCommande == 0)
                        {
                            ViewBag.SiPaye = false;
                            ViewBag.cmdAPayer = k.mCmdID;
                        }
                    }

                    return View(commandes.ToList());
                }
            }

            else
                return RedirectToAction("Login", "Account");
        }



        // KEVIN ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // GET: Commandes
        public ActionResult CommanderClient(string sortOrder, string Allergy)
        {
            if (@Session["Connexion"] != null)
            {
                if ((bool)@Session["Connexion"] == false)
                {
                    return RedirectToAction("Login", "Account");
                }

                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewBag.PrixSortParm = sortOrder == "Prix" ? "prix_desc" : "Prix";
                ViewBag.AllergyParam = String.IsNullOrEmpty(Allergy) ? "Show" : null;
                ViewBag.TitreAllergie = Allergy == "Show" ? true : false;
                var Menu = (from s in db.Menus
                            where s.m_iMenuId == 1
                            select s).FirstOrDefault();


                int UseId = Convert.ToInt32(@Session["ID"]);

                var User = (from s in db.Utilisateurs
                            where s.UtilisateurID == UseId
                            select s).FirstOrDefault();

                var Repas = Menu.m_Repas;
                List<CRepas> SansAllergie = new List<CRepas>();
                foreach (var rep in Repas)
                {

                    if ((!(User.m_boArachide && rep.m_boArachide) && !(User.m_boBle && rep.m_boBle) && !(User.m_boCrustace && rep.m_boCrustace)
                        && !(User.m_boFruitCoque && rep.m_boFruitCoque) && !(User.m_boLait && rep.m_boMollusque) && !(User.m_boOeuf && rep.m_boOeuf) &&
                        !(User.m_boPoisson && rep.m_boPoisson) && !(User.m_boSesame && rep.m_boSesame) && !(User.m_boSoja && rep.m_boSoja)) || (Allergy != null))
                    {
                        foreach (var rabais in rep.RepasRabais)
                        {
                            if ((rabais.RabaisDateDebut <= DateTime.Now) && (rabais.RabaisDateFin >= DateTime.Now))
                            {
                                rep.m_iPrix = rep.m_iPrix - (rep.m_iPrix * Convert.ToDecimal((rabais.RabaisPrix / 100.00)));
                            }
                        }
                        SansAllergie.Add(rep);
                    }

                }

                switch (sortOrder)
                {
                    case "name_desc":
                        SansAllergie = SansAllergie.OrderByDescending(x => x.m_strNom).ToList();
                        break;
                    case "Prix":
                        SansAllergie = SansAllergie.OrderBy(s => s.m_iPrix).ToList();
                        break;
                    case "prix_desc":
                        SansAllergie = SansAllergie.OrderByDescending(s => s.m_iPrix).ToList();
                        break;
                    default:
                        SansAllergie = SansAllergie.OrderBy(x => x.m_strNom).ToList();
                        break;
                }

                Menu.m_Repas = SansAllergie;
                return View(Menu);
            }
            else
                return RedirectToAction("Login", "Account");
        }

        public ActionResult AjouterCmd(FormCollection collection)
        {
            if (@Session["Connexion"] != null)
            {
                if ((bool)@Session["Connexion"] == false)
                {
                    return RedirectToAction("Login", "Account");
                }

                var Cmd = new CCommande();

                Cmd.CRestoID = Convert.ToInt32(@Session["RestoID"]);
                Cmd.CTableID = Convert.ToInt32(@Session["TableID"]);
                Cmd.mCmdCommentCommandes = collection.Get("CmdNote");
                Cmd.mCmdDate = DateTime.Now;
                Cmd.mCmdStatusCommande = 0;
                Cmd.UtilisateurID = Convert.ToInt32(@Session["ID"]);

                db.Commandes.Add(Cmd);
                db.SaveChanges();


                // int LastID = db.Commandes.Last().mCmdID;
                var tempo = db.Commandes.OrderByDescending(s => s.mCmdID).First();

                int LastID = tempo.mCmdID;

                var Menu = (from s in db.Menus
                            where s.m_iMenuId == 1
                            select s).FirstOrDefault();

                List<CCmdRepas> lstRepas = new List<CCmdRepas>();


                double dSomme = 0;
                double dSommeTotale = 0;

                foreach (var Repas in Menu.m_Repas)
                {
                    var Valeur = collection.Get("Rep " + Repas.m_iRepasId);
                    if (Valeur != "")
                    {
                        int NbRep = Convert.ToInt32(Valeur);
                        if (NbRep > 0)
                        {
                            CCmdRepas Rep = new CCmdRepas();
                            Rep.mNbRep = NbRep;
                            Rep.mCommentaire = collection.Get("Note " + Repas.m_iRepasId);
                            Rep.mCmdID = LastID;
                            Rep.m_iRepasId = Repas.m_iRepasId;

                            db.CommandeRepas.Add(Rep);
                            db.SaveChanges();
                        }
                    }
                }

                var tabTempo = from s in db.CommandeRepas
                               where s.mCmdID == LastID
                               select s;

                tabTempo = tabTempo.Include(x => x.mRepas);


                foreach (var w in tabTempo)
                {
                    dSomme += ((double)w.mRepas.m_iPrix * w.mNbRep);
                }


                dSommeTotale = dSomme * 1.15;

                decimal ddSomme = Convert.ToDecimal(dSomme);
                decimal ddSommeTotale = Convert.ToDecimal(dSommeTotale);
                string strCon = System.Web
                      .Configuration
                      .WebConfigurationManager
                      .ConnectionStrings["CRestoContext"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    string sql = "UPDATE CCommandes SET mCmdPrixAvantTaxes = @Prix, mCmdPrixTotal = @PrixTotal WHERE mCmdID = @comID";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Prix", ddSomme);
                        cmd.Parameters.AddWithValue("@PrixTotal", ddSommeTotale);
                        cmd.Parameters.AddWithValue("@comID", LastID);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                return RedirectToAction("Details", new { id = LastID });

            }

            else
                return RedirectToAction("Login", "Account");

        }



        // GET: Commandes
        public ActionResult PayerFacture(int? id)
        {
            string strCon = System.Web
                      .Configuration
                      .WebConfigurationManager
                      .ConnectionStrings["CRestoContext"].ConnectionString;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CCommande cCommande = db.Commandes.Find(id);

            if (cCommande == null)
            {
                return HttpNotFound();
            }

            using (SqlConnection conn = new SqlConnection(strCon))
            {
                string sql = "UPDATE CCommandes SET mCmdStatusCommande = 1 WHERE mCmdID = @comID";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@comID", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            if (Session["Type"].ToString() == "Client")
                return RedirectToAction("Index");
            else
                return RedirectToAction("IndexAGS");
        }


        public ActionResult SelectionTable()
        {

            int noResto = Convert.ToInt32(Session["RestoID"]);

            var lstTables = from s in db.Tables
                            where s.CRestoID == noResto
                            select s;

            ViewBag.listeTables = new SelectList(lstTables, "CTableID", "i_TableNum");

            return View();
        }


        public ActionResult AjouterTableSession(FormCollection collection)
        {
            @Session["TableID"] = Convert.ToInt32(collection.Get("listeTables"));

            return RedirectToAction("CommanderClient");
        }


        // GET: Commandes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            CCommande cCommande = db.Commandes.Find(id);

            if (cCommande == null)
            {
                return HttpNotFound();
            }

            var lstRepas = from s in db.CommandeRepas
                           where s.mCmdID == id
                           select s;

            lstRepas = lstRepas.Include(x => x.mRepas);


            //  List<CCmdRepas> lstRepas = cCommande.mCmdColletionRepas.ToList();

            ViewBag.YourMeet = lstRepas.ToList();

            return View(cCommande);
        }

        // GET: Commandes/Create
        public ActionResult Create(int? _Special)
        {
            if (@Session["Connexion"] != null)
            {
                if ((bool)@Session["Connexion"] == false)
                {
                    return RedirectToAction("Login", "Account");
                }

                else if (_Special != null)
                {
                    if (@Session["Type"].ToString() == "Administrateur")
                    {
                        //Eager Loading
                        var vmCommande = new RepasZCommandes();

                        var lstRepas = from s in db.Repas
                                       select s;

                        vmCommande.AllRepas = lstRepas.ToList();

                        ViewBag.LesRepas = vmCommande.AllRepas;
                        ViewBag.CRestoID = new SelectList(db.Resto, "CRestoID", "resNom");
                        ViewBag.CTableID = new SelectList(db.Tables, "CTableID", "i_TableNum");
                        ViewBag.UtilisateurID = new SelectList(db.Utilisateurs, "UtilisateurID", "UtilisateurNomUsager");

                        return View();
                    }

                    return RedirectToAction("Index");
                }

                else
                {
                    if (@Session["TableID"] == null)
                        return RedirectToAction("SelectionTable");
                    else
                        return RedirectToAction("CommanderClient");
                }
            }

            else
                return RedirectToAction("Login", "Account");
        }

        // POST: Commandes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mCmdID,mCmdStatusCommande,UtilisateurID,CRestoID,CTableID,mCmdCommentCommandes,mCmdPrixAvantTaxes,mCmdPrixTotal,mCmdDate")] CCommande cCommande)
        {
            if (ModelState.IsValid)
            {
                db.Commandes.Add(cCommande);
                db.SaveChanges();
                return RedirectToAction("IndexAGS");
            }

            ViewBag.CRestoID = new SelectList(db.Resto, "CRestoID", "resNom", cCommande.CRestoID);
            ViewBag.CTableID = new SelectList(db.Tables, "CTableID", "i_TableNum", cCommande.CTableID);
            ViewBag.UtilisateurID = new SelectList(db.Utilisateurs, "UtilisateurID", "UtilisateurNomUsager", cCommande.UtilisateurID);
            return View(cCommande);
        }

        // GET: Commandes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Login", "Account");
            }
            CCommande cCommande = db.Commandes.Find(id);
            if (cCommande == null)
            {
                return HttpNotFound();
            }
            ViewBag.CRestoID = new SelectList(db.Resto, "CRestoID", "resNom", cCommande.CRestoID);
            ViewBag.CTableID = new SelectList(db.Tables, "CTableID", "i_TableNum", cCommande.CTableID);
            ViewBag.UtilisateurID = new SelectList(db.Utilisateurs, "UtilisateurID", "UtilisateurNomUsager", cCommande.UtilisateurID);
            return View(cCommande);
        }

        // POST: Commandes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mCmdID,mCmdStatusCommande,UtilisateurID,CRestoID,CTableID,mCmdCommentCommandes,mCmdPrixAvantTaxes,mCmdPrixTotal,mCmdDate")] CCommande cCommande)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cCommande).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CRestoID = new SelectList(db.Resto, "CRestoID", "resNom", cCommande.CRestoID);
            ViewBag.CTableID = new SelectList(db.Tables, "CTableID", "i_TableNum", cCommande.CTableID);
            ViewBag.UtilisateurID = new SelectList(db.Utilisateurs, "UtilisateurID", "UtilisateurNomUsager", cCommande.UtilisateurID);
            return View(cCommande);
        }

        // GET: Commandes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Login", "Account");
            }
            CCommande cCommande = db.Commandes.Find(id);
            if (cCommande == null)
            {
                return HttpNotFound();
            }

            List<CCmdRepas> lstRepas = cCommande.mCmdColletionRepas.ToList();

            ViewBag.YourMeet = lstRepas;

            return View(cCommande);
        }

        // POST: Commandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CCommande cCommande = db.Commandes.Find(id);
            db.Commandes.Remove(cCommande);
            db.SaveChanges();
            return RedirectToAction("Index");
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
