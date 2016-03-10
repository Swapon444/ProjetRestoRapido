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
    public class RabaisRepasController : Controller
    {
        private CRestoContext db = new CRestoContext();

        // GET: RabaisRepas
        public ActionResult Index()
        {
            if (@Session["Type"] != null)
                if (@Session["Type"].ToString() == "Gerant")
                {
                    var rabais = db.Rabais.Include(c => c.Repas);
                    return View(rabais.ToList());
                }

            return View("../Home/Index");
            
        }

        // GET: RabaisRepas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRabaisRepas cRabaisRepas = db.Rabais.Find(id);
            if (cRabaisRepas == null)
            {
                return HttpNotFound();
            }
            return View(cRabaisRepas);
        }

        // GET: RabaisRepas/Create
        public ActionResult Create()
        {
            if (@Session["Type"] != null)
                if (@Session["Type"].ToString() == "Gerant")
                {
                    ViewBag.m_iRepasId = new SelectList(db.Repas, "m_iRepasId", "m_strNom");
                    return View();
                }
            return View("../Home/Index");
        }

        // POST: RabaisRepas/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RabaisID,m_iRepasId,RabaisPrix,RabaisDateDebut,RabaisDateFin")] CRabaisRepas cRabaisRepas)
        {
            if (ModelState.IsValid)
            {
                db.Rabais.Add(cRabaisRepas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.m_iRepasId = new SelectList(db.Repas, "m_iRepasId", "m_strNom", cRabaisRepas.m_iRepasId);
            return View(cRabaisRepas);
        }

        // GET: RabaisRepas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRabaisRepas cRabaisRepas = db.Rabais.Find(id);
            if (cRabaisRepas == null)
            {
                return HttpNotFound();
            }
            ViewBag.m_iRepasId = new SelectList(db.Repas, "m_iRepasId", "m_strNom", cRabaisRepas.m_iRepasId);
            return View(cRabaisRepas);
        }

        // POST: RabaisRepas/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RabaisID,m_iRepasId,RabaisPrix,RabaisDateDebut,RabaisDateFin")] CRabaisRepas cRabaisRepas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cRabaisRepas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.m_iRepasId = new SelectList(db.Repas, "m_iRepasId", "m_strNom", cRabaisRepas.m_iRepasId);
            return View(cRabaisRepas);
        }

        // GET: RabaisRepas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRabaisRepas cRabaisRepas = db.Rabais.Find(id);
            if (cRabaisRepas == null)
            {
                return HttpNotFound();
            }
            return View(cRabaisRepas);
        }

        // POST: RabaisRepas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CRabaisRepas cRabaisRepas = db.Rabais.Find(id);
            db.Rabais.Remove(cRabaisRepas);
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
