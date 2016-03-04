using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestoRapido.Models;
using System.Security.Cryptography;

namespace RestoRapido.Controllers
{
    public class GerantController : Controller
    {
        private CRestoContext db = new CRestoContext();

        public ActionResult Index()
        {
            if (@Session["Type"] == null)
                return View("../Shared/Error");

            else if (@Session["Type"].ToString() == "Gerant")
                return View();
            else
                return View("../Shared/Error");
        }



        public ActionResult Creation()
        {
            if (@Session["Type"] == null)
                return View("../Shared/Error");

            else if (@Session["Type"].ToString() == "Gerant")
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
                utilisateur.UtilisateurMDP = CEncryption.CalculateMD5Hash(utilisateur.UtilisateurMDP);
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
