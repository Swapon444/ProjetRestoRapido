using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Restaurent.Models;

namespace Restaurent.Controllers
{
    public class CTablesController : Controller
    {
        private TableContext db = new TableContext();

        // GET: CTables
        public ActionResult Index()
        {
            return View(db.tblTables.ToList());
        }

        // GET: CTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTable cTable = db.tblTables.Find(id);
            if (cTable == null)
            {
                return HttpNotFound();
            }
            return View(cTable);
        }

        // GET: CTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "i_TableID,i_TableNum,i_RestaurantID")] CTable cTable)
        {
            if (ModelState.IsValid)
            {
                db.tblTables.Add(cTable);
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
            CTable cTable = db.tblTables.Find(id);
            if (cTable == null)
            {
                return HttpNotFound();
            }
            return View(cTable);
        }

        // POST: CTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "i_TableID,i_TableNum,i_RestaurantID")] CTable cTable)
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
            CTable cTable = db.tblTables.Find(id);
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
            CTable cTable = db.tblTables.Find(id);
            db.tblTables.Remove(cTable);
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
