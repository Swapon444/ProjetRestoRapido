using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestoRapido.Models;

namespace RestoRapido.Controllers
{
    public class CommandesController : Controller
    {
        private CRestoContext db = new CRestoContext();

        // GET: Commandes
        public ActionResult Index()
        {
            var commandes = from s in db.Commandes
                            select s;


            if (Session["Connexion"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            else if (Session["Type"].ToString() == "Client")
            {
                commandes.Where(s => s.UtilisateurID == Convert.ToInt32(@Session["ID"]));
            }

            else if (Session["Type"].ToString() == "Serveur")
            {


            }


            commandes = commandes.Include(c => c.mCmdResto).Include(c => c.mCmdTable).Include(c => c.mUtilisateurClient);
            return View(commandes.ToList());
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
            return View(cCommande);
        }

        // GET: Commandes/Create
        public ActionResult Create()
        {
            ViewBag.CRestoID = new SelectList(db.Resto, "CRestoID", "resNom");
            ViewBag.CTableID = new SelectList(db.Tables, "CTableID", "i_TableNum");
            ViewBag.UtilisateurID = new SelectList(db.Utilisateurs, "UtilisateurID", "UtilisateurNomUsager");
            return View();
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
                return RedirectToAction("Index");
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
