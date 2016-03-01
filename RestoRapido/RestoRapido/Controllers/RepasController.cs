﻿using System;
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
    public class RepasController : Controller
    {
        private CRestoContext db = new CRestoContext();

        // GET: Repas
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NomSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PrixSortParm = sortOrder == "Prix" ? "prix_desc" : "Prix";

            var repas = from s in db.Repas select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                repas = repas.Where(s => s.m_strNom.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    repas = repas.OrderByDescending(s => s.m_strNom);
                    break;
                case "Prix":
                    repas = repas.OrderBy(s => s.m_iPrix);
                    break;
                case "prix_desc":
                    repas = repas.OrderByDescending(s => s.m_iPrix);
                    break;
                default:
                    repas = repas.OrderBy(s => s.m_strNom);
                    break;
            }

            return View(repas.ToList());
        }

        // GET: Repas/Details/5
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

        // GET: Repas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Repas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "m_iRepasId,m_strNom,m_iPrix,m_strDescription,m_boBle,m_boLait,m_boOeuf,m_boArachide,m_boSoja,m_boFruitCoque,m_boPoisson,m_boSesame,m_boCrustace,m_boMollusque")] CRepas cRepas)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Repas.Add(cRepas);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Création impossible. Veuillez réessayer.");
            }

            return View(cRepas);
        }

        // GET: Repas/Edit/5
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

        // POST: Repas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "m_iRepasId,m_strNom,m_iPrix,m_strDescription,m_boBle,m_boLait,m_boOeuf,m_boArachide,m_boSoja,m_boFruitCoque,m_boPoisson,m_boSesame,m_boCrustace,m_boMollusque")] CRepas cRepas)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(cRepas).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Modification impossible. Veuillez réessayer.");
            }

            return View(cRepas);
        }

        // GET: Repas/Delete/5
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

        // POST: Repas/Delete/5
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