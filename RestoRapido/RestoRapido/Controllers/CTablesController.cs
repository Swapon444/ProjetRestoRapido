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
    public class CTablesController : Controller
    {
        private CRestoContext db = new CRestoContext();

        // GET: CTables
        public ActionResult Index()
        {
            return View(db.Tables.ToList());
        }

        // GET: CTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTable cTable = db.Tables.Find(id);
            if (cTable == null)
            {
                return HttpNotFound();
            }
            return View(cTable);
        }

        // GET: CTables/Create
        public ActionResult Create(int id)
        {
            ViewBag.id = id;
            return View();
        }

        // POST: CTables/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CTableID,i_TableNum,cqr_TableCodeQR")] CTable cTable)
        {
            if (ModelState.IsValid)
            {
                db.Tables.Add(cTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cTable);
        }

        // GET: CTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTable cTable = db.Tables.Find(id);
            if (cTable == null)
            {
                return HttpNotFound();
            }
            return View(cTable);
        }

        // POST: CTables/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CTableID,i_TableNum,cqr_TableCodeQR")] CTable cTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cTable);
        }

        // GET: CTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTable cTable = db.Tables.Find(id);
            if (cTable == null)
            {
                return HttpNotFound();
            }
            return View(cTable);
        }

        // POST: CTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CTable cTable = db.Tables.Find(id);
            db.Tables.Remove(cTable);
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
