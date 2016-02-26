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
    public class CAlertesController : Controller
    {
        private CRestoContext db = new CRestoContext();

        // GET: CAlertes
        public ActionResult Index()
        {
            return View(db.Alertes.ToList());
        }

        // GET: CAlertes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAlerte cAlerte = db.Alertes.Find(id);
            if (cAlerte == null)
            {
                return HttpNotFound();
            }
            return View(cAlerte);
        }

        // GET: CAlertes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CAlertes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlerteID,AlerteClientID,AlerteServeurID")] CAlerte cAlerte)
        {
            if (ModelState.IsValid)
            {
                db.Alertes.Add(cAlerte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cAlerte);
        }

        // GET: CAlertes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAlerte cAlerte = db.Alertes.Find(id);
            if (cAlerte == null)
            {
                return HttpNotFound();
            }
            return View(cAlerte);
        }

        // POST: CAlertes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlerteID,AlerteClientID,AlerteServeurID")] CAlerte cAlerte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cAlerte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cAlerte);
        }

        // GET: CAlertes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAlerte cAlerte = db.Alertes.Find(id);
            if (cAlerte == null)
            {
                return HttpNotFound();
            }
            return View(cAlerte);
        }

        // POST: CAlertes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CAlerte cAlerte = db.Alertes.Find(id);
            db.Alertes.Remove(cAlerte);
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
