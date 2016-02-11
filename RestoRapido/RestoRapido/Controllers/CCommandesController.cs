﻿using System;
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
    public class CCommandesController : Controller
    {
        private CRestoContext db = new CRestoContext();

        // GET: CCommandes
        public ActionResult Index()
        {
            return View(db.Commandes.ToList());
        }

        // GET: CCommandes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CCommande cCommande = db.Commandes.Find(id);
            if (cCommande == null)
            {
                return HttpNotFound();
            }
            return View(cCommande);
        }

        // GET: CCommandes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CCommandes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mCmdID,mCmdClientID,mCmdRestoID,mCmdTableID,mCmdServerID,mCmdCommentCommandes,mCmdPrixAvantTaxes,mCmdPrixTotal,mCmdStatusCommande,mCmdDate")] CCommande cCommande)
        {
            if (ModelState.IsValid)
            {
                db.Commandes.Add(cCommande);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cCommande);
        }

        // GET: CCommandes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CCommande cCommande = db.Commandes.Find(id);
            if (cCommande == null)
            {
                return HttpNotFound();
            }
            return View(cCommande);
        }

        // POST: CCommandes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mCmdID,mCmdClientID,mCmdRestoID,mCmdTableID,mCmdServerID,mCmdCommentCommandes,mCmdPrixAvantTaxes,mCmdPrixTotal,mCmdStatusCommande,mCmdDate")] CCommande cCommande)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cCommande).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cCommande);
        }

        // GET: CCommandes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CCommande cCommande = db.Commandes.Find(id);
            if (cCommande == null)
            {
                return HttpNotFound();
            }
            return View(cCommande);
        }

        // POST: CCommandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CCommande cCommande = db.Commandes.Find(id);
            db.Commandes.Remove(cCommande);
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