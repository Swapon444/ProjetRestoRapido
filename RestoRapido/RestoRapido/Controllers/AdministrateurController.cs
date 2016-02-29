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

    public class AdministrateurController : Controller
    {

        private CRestoContext db = new CRestoContext();

        public ActionResult Index()
        {
            if (@Session["Type"].ToString() == "Administrateur")
            {
               // @Session["IDUser"] = db.
                return View();
            }
               
            else
                return View("../Shared/Error");
        }



        public ActionResult Creation()
        {
            if (@Session["Type"].ToString() == "Administrateur")
                return View();
            else
                return View("../Shared/Error");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Creation([Bind(Include = "UtilisateurID,UtilisateurMDP,UtilisateurNomUsager,UtilisateurNom,UtilisateurPrenom,UtilisateurType")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                db.Utilisateurs.Add(utilisateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(utilisateur);
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
