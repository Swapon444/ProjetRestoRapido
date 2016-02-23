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
    public class CMenusController : Controller
    {
        private CRestoContext db = new CRestoContext();

        // GET: CMenus
        public ActionResult Index()
        {
            return View(db.Menus.ToList());
        }

        // GET: CMenus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMenu cMenu = db.Menus.Find(id);
            if (cMenu == null)
            {
                return HttpNotFound();
            }
            return View(cMenu);
        }

        // GET: CMenus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMenus/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "m_iMenuId,m_strNom,m_DateDebut,m_DateFin")] CMenu cMenu)
        {
            if (ModelState.IsValid)
            {
                db.Menus.Add(cMenu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cMenu);
        }

        // GET: CMenus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMenu cMenu = db.Menus.Find(id);
            if (cMenu == null)
            {
                return HttpNotFound();
            }
            return View(cMenu);
        }

        // POST: CMenus/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "m_iMenuId,m_strNom,m_DateDebut,m_DateFin")] CMenu cMenu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cMenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cMenu);
        }

        // GET: CMenus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMenu cMenu = db.Menus.Find(id);
            if (cMenu == null)
            {
                return HttpNotFound();
            }
            return View(cMenu);
        }

        // POST: CMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CMenu cMenu = db.Menus.Find(id);
            db.Menus.Remove(cMenu);
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
