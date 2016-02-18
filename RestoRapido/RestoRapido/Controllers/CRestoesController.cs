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
    public class CRestoesController : Controller
    {
        private CRestoContext db = new CRestoContext();

        // GET: CRestoes
        public ActionResult Index()
        {
            return View(db.Resto.ToList());
        }

        // GET: CRestoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CResto cResto = db.Resto.Find(id);
            if (cResto == null)
            {
                return HttpNotFound();
            }
            return View(cResto);
        }

        // GET: CRestoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CRestoes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CRestoID,resNom,resPostal,resRue,resNoCiv")] CResto cResto)
        {
            if (ModelState.IsValid)
            {
                db.Resto.Add(cResto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cResto);
        }

        // GET: CRestoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CResto cResto = db.Resto.Find(id);
            if (cResto == null)
            {
                return HttpNotFound();
            }
            return View(cResto);
        }

        // POST: CRestoes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CRestoID,resNom,resPostal,resRue,resNoCiv")] CResto cResto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cResto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cResto);
        }

        // GET: CRestoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CResto cResto = db.Resto.Find(id);
            if (cResto == null)
            {
                return HttpNotFound();
            }
            return View(cResto);
        }

        // POST: CRestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CResto cResto = db.Resto.Find(id);
            db.Resto.Remove(cResto);
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
