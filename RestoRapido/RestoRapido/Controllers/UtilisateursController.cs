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
    public class UtilisateursController : Controller
    {
        private CRestoContext db = new CRestoContext();

        // GET: Utilisateurs1
        public ActionResult Index()
        {
            if (@Session["Type"] != null)
                if ((@Session["Type"].ToString() == "Administrateur") || ((@Session["Type"].ToString() == "Gerant")))
                    return View(db.Utilisateurs.ToList());

            return View("../Home/Index");

           
        }

        // GET: Utilisateurs1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("../Home/Index");
            }
            Utilisateur utilisateur = db.Utilisateurs.Find(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // GET: Utilisateurs1/Create
        public ActionResult Create()
        {
            if (@Session["Type"] != null)
            {
                if ((@Session["Type"].ToString() == "Administrateur") || ((@Session["Type"].ToString() == "Gerant")))
                    return View();
                return View("../Home/Index");
            }
            else
                return View("../Home/Index");
        }

        // POST: Utilisateurs1/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UtilisateurID,UtilisateurMDP,UtilisateurNomUsager,UtilisateurNom,UtilisateurPrenom,UtilisateurType,m_boBle,m_boLait,m_boOeuf,m_boArachide,m_boSoja,m_boFruitCoque,m_boPoisson,m_boSesame,m_boCrustace,m_boMollusque")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                utilisateur.UtilisateurMDP = CEncryption.CalculateMD5Hash(utilisateur.UtilisateurMDP);
                db.Utilisateurs.Add(utilisateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(utilisateur);
        }

        // GET: Utilisateurs1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = db.Utilisateurs.Find(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // POST: Utilisateurs1/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UtilisateurID,UtilisateurMDP,UtilisateurNomUsager,UtilisateurNom,UtilisateurPrenom,UtilisateurType,m_boBle,m_boLait,m_boOeuf,m_boArachide,m_boSoja,m_boFruitCoque,m_boPoisson,m_boSesame,m_boCrustace,m_boMollusque")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilisateur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(utilisateur);
        }

        // GET: Utilisateurs1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("../Home/Index");
            }
            Utilisateur utilisateur = db.Utilisateurs.Find(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // POST: Utilisateurs1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utilisateur utilisateur = db.Utilisateurs.Find(id);
            db.Utilisateurs.Remove(utilisateur);
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
