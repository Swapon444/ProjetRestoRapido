using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestoRapido.Models;
using System.Data.Entity.Infrastructure;

namespace RestoRapido.Controllers
{
    public class CRabaisController : Controller
    {
        private CRestoContext db = new CRestoContext();

        // GET: CRabais
        public ActionResult Index()
        {
            return View(db.Rabais.ToList());
        }

        // GET: CRabais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRabais cRabais = db.Rabais.Find(id);
            if (cRabais == null)
            {
                return HttpNotFound();
            }
            return View(cRabais);
        }

        // GET: CRabais/Create
        public ActionResult Create()
        {
            PopulateRepasDropDownList();
            return View();
        }

        // POST: CRabais/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RabaisID,RabaisRepasID,RabaisPrix,RabaisDateDebut,RabaisDateFin")] CRabais cRabais)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Rabais.Add(cRabais);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateRepasDropDownList(cRabais.RabaisRepasID);

            return View(cRabais);
        }

        // GET: CRabais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRabais cRabais = db.Rabais.Find(id);

            if (cRabais == null)
            {
                return HttpNotFound();
            }
            PopulateRepasDropDownList(cRabais.RabaisRepasID);
            return View(cRabais);
        }

        // POST: CRabais/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            var RabaisToUpdate = db.Rabais.Find(id);
            if (TryUpdateModel(RabaisToUpdate, "",
               new string[] { "Nom du repas", "Rabais en %", "Date de début", "Date de fin" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            PopulateRepasDropDownList(RabaisToUpdate.RabaisID);
            return View(RabaisToUpdate);
        }

        // GET: CRabais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRabais cRabais = db.Rabais.Find(id);
            if (cRabais == null)
            {
                return HttpNotFound();
            }
            return View(cRabais);
        }

        // POST: CRabais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CRabais cRabais = db.Rabais.Find(id);
            db.Rabais.Remove(cRabais);
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

        private void PopulateRepasDropDownList(object selectedRepas = null)
        {
            var RepasQuery = from d in db.Repas
                                   orderby d.m_strNom
                                   select d;
            ViewBag.RepasID = new SelectList(RepasQuery, "RepasID", "Nom", selectedRepas);
        }
    }

}
