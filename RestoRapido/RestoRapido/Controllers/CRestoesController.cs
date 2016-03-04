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
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var restos = from s in db.Resto
                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                restos = restos.Where(s => s.resNom.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    restos = restos.OrderByDescending(s => s.resNom);
                    break;
                default:
                    restos = restos.OrderBy(s => s.resNom);
                    break;
            }
            return View(restos.ToList());
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


        /*
        Permet de supprimer une table
            id : Clé primaire du restaurant
            idTable = Clé primaire de la table
        */
        public ActionResult supprimertable(int id, int idTable)
        {
           // CResto cResto = db.Resto.Find(id); //va chercher le restaurant
            CTable Table = db.Tables.Find(idTable); //va chercher la table

            db.Tables.Remove(Table); //enlève cette table

            db.SaveChanges(); //Sauvegarde la BD

            return RedirectToAction("Edit", new { ID = id });
        }

        /*
        Permet d'ajouter une table
            id : clé primaire du restaurant
        */
        public ActionResult ajoutertable(int id)
        {
            CResto cResto = db.Resto.Find(id); //va chercher le restaurant



            try
            {
                //Ajoute la table au restaurant
                cResto.Tables.Add(new CTable(cResto.Tables.Last().i_TableNum + 1, id));
            }
            catch (Exception e)
            {
                cResto.Tables.Add(new CTable(1, id));
            }

            db.SaveChanges(); //Sauvegarde la BD

            return RedirectToAction("Edit", new { ID = id });
        }
    }
}
