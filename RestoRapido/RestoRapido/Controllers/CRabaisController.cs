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
            return View();
        }

        // POST: CRabais/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RabaisID,RabaisRepasNom,RabaisPrix,RabaisDateDebut,RabaisDateFin")] CRabais cRabais)
        {
            if (ModelState.IsValid)
            {
                db.Rabais.Add(cRabais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            return View(cRabais);
        }

        // POST: CRabais/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RabaisID,RabaisRepasNom,RabaisPrix,RabaisDateDebut,RabaisDateFin")] CRabais cRabais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cRabais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cRabais);
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
    }
}
