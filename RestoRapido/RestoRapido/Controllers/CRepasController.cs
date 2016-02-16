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
    public class CRepasController : Controller
    {
        private CRestoContext db = new CRestoContext();

        // GET: CRepas
        public ActionResult Index()
        {
            return View(db.Repas.ToList());
        }

        // GET: CRepas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRepas cRepas = db.Repas.Find(id);
            if (cRepas == null)
            {
                return HttpNotFound();
            }
            return View(cRepas);
        }

        // GET: CRepas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CRepas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mRepID,mRepNom")] CRepas cRepas)
        {
            if (ModelState.IsValid)
            {
                db.Repas.Add(cRepas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cRepas);
        }

        // GET: CRepas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRepas cRepas = db.Repas.Find(id);
            if (cRepas == null)
            {
                return HttpNotFound();
            }
            return View(cRepas);
        }

        // POST: CRepas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mRepID,mRepNom")] CRepas cRepas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cRepas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cRepas);
        }

        // GET: CRepas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRepas cRepas = db.Repas.Find(id);
            if (cRepas == null)
            {
                return HttpNotFound();
            }
            return View(cRepas);
        }

        // POST: CRepas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CRepas cRepas = db.Repas.Find(id);
            db.Repas.Remove(cRepas);
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
