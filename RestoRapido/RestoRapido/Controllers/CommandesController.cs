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
            ViewBag.Type = Session["Type"].ToString();

            if (@Session["Connexion"] != null)
            {
                if ((bool)@Session["Connexion"] == false)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           
        }
        


        // GET: Commandes
        public ActionResult IndexServeur()
        {

            if (@Session["Connexion"] != null)
            {
                if ((bool)@Session["Connexion"] == false)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                else
                {
                    int i = Convert.ToInt32(@Session["ID"]);

                    var commandes = from t1 in db.Commandes
                                    join t2 in db.Tables on t1.CTableID equals t2.CTableID
                                    join t3 in db.TableUtilisateurs on t2.CTableID equals t3.CTableID
                                    join t4 in db.Utilisateurs on t3.UtilisateurID equals t4.UtilisateurID
                                    where t1.mCmdStatusCommande == 0 && t3.UtilisateurID == i
                                    select t1;

                    
                    commandes = commandes.Include(c => c.mCmdResto).Include(c => c.mCmdTable).Include(c => c.mUtilisateurClient);
                    commandes.OrderBy(y => y.mCmdTable.i_TableNum);
                    return View(commandes.ToList());
                }
            }

            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


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
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }



        // KEVIN ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // GET: Commandes
        public ActionResult CommanderClient(int? id)
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
            return View(cCommande);
        }



        // GET: Commandes
        public ActionResult PayerFacture(int? id)
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

            using (SqlConnection conn = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\dbRestoRapidoV20.mdf;Initial Catalog=RestoRapido;Integrated Security=True"))
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

            if(Session["Type"].ToString() == "Client")
                return RedirectToAction("Index");
            else
                return RedirectToAction("IndexAGS");
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


            List<CRepas> lstRepas = cCommande.mCmdColletionRepas.ToList();

            ViewBag.YourMeet = lstRepas;

            return View(cCommande);
        }

        // GET: Commandes/Create
        public ActionResult Create()
        {
            if (@Session["Connexion"] != null)
            {
                if ((bool)@Session["Connexion"] == false)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                else
                {                 
                    if (@Session["Type"].ToString() == "Client")
                    {
                        return RedirectToAction("CommanderClient", new { id = Convert.ToInt32(@Session["ID"]) });
                    }

                    else
                  //  else if(@Session["Type"].ToString() != "Serveur")
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

                  //  else
                       // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }

            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CCommande cCommande = db.Commandes.Find(id);
            if (cCommande == null)
            {
                return HttpNotFound();
            }

            List<CRepas> lstRepas = cCommande.mCmdColletionRepas.ToList();

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
