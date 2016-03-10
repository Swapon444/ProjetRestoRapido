using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestoRapido.Models;
using RestoRapido.ViewModels;
using System.Data.Entity.Infrastructure;

namespace RestoRapido.Controllers
{
    public class MenusController : Controller
    {
        private CRestoContext db = new CRestoContext();

        // GET: Menus
        public ActionResult Index(string sortOrder, string searchString)
        {
            if (@Session["Type"] != null)
            {
                ViewBag.NomSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewBag.DateDebutSortParm = sortOrder == "DateDebut" ? "date_debut_desc" : "DateDebut";
                ViewBag.DateFinSortParm = sortOrder == "DateFin" ? "date_fin_desc" : "DateFin";
                ViewBag.NbRepasSortParm = sortOrder == "NbRepas" ? "nb_repas_desc" : "NbRepas";

                var menus = from s in db.Menus select s;

                if (!string.IsNullOrEmpty(searchString))
                {
                    menus = menus.Where(s => s.m_strNom.Contains(searchString));
                }

                switch (sortOrder)
                {
                    case "name_desc":
                        menus = menus.OrderByDescending(s => s.m_strNom);
                        break;
                    case "DateDebut":
                        menus = menus.OrderBy(s => s.m_DateDebut);
                        break;
                    case "date_debut_desc":
                        menus = menus.OrderByDescending(s => s.m_DateDebut);
                        break;
                    case "DateFin":
                        menus = menus.OrderBy(s => s.m_DateFin);
                        break;
                    case "date_fin_desc":
                        menus = menus.OrderByDescending(s => s.m_DateFin);
                        break;
                    case "NbRepas":
                        menus = menus.OrderBy(s => s.m_Repas.Count);
                        break;
                    case "nb_repas_desc":
                        menus = menus.OrderByDescending(s => s.m_Repas.Count);
                        break;
                    default:
                        menus = menus.OrderBy(s => s.m_strNom);
                        break;
                }

                return View(menus.ToList());
            }

            return View("../Home/Index");
        }

        // GET: Menus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("../Home/Index");
            }
            CMenu cMenu = db.Menus.Find(id);
            if (cMenu == null)
            {
                return HttpNotFound();
            }
            return View(cMenu);
        }

        // GET: Menus/Create
        public ActionResult Create()
        {
            if (@Session["Type"] != null)
                return View();

            return View("../Home/Index");
        }

        // POST: Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "m_iMenuId,m_strNom,m_DateDebut,m_DateFin")] CMenu cMenu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Menus.Add(cMenu);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Création impossible. Veuillez réessayer.");
            }

            return View(cMenu);
        }

        // GET: Menus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View("../Home/Index");
            }

            CMenu cMenu = db.Menus
                .Include(i => i.m_Repas)
                .Where(i => i.m_iMenuId == id)
                .Single();

            RemplirAssignationsRepas(cMenu);

            if (cMenu == null)
            {
                return HttpNotFound();
            }

            return View(cMenu);
        }

        void RemplirAssignationsRepas(CMenu menu)
        {

            var allRepas = db.Repas;
            var menuRepas = new HashSet<int>(menu.m_Repas.Select(r => r.m_iRepasId));
            var viewModel = new List<CRepasAssignes>();

            foreach (var repas in allRepas)
            {
                viewModel.Add(new CRepasAssignes
                {
                    m_iRepasId = repas.m_iRepasId,
                    m_strNom = repas.m_strNom,
                    m_boAssigne = menuRepas.Contains(repas.m_iRepasId)
                });
            }

            ViewBag.Repas = viewModel;
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "m_iMenuId,m_strNom,m_DateDebut,m_DateFin")] CMenu cMenu, int? id, string[] repasChoisis)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var menuAChanger = db.Menus
                .Include(i => i.m_Repas)
                .Where(i => i.m_iMenuId == id)
                .Single();

            if (TryUpdateModel(menuAChanger, "", 
                new string[] { "m_iMenuId", "m_strNom", "m_DateDebut", "m_DateFin" }))
            {
                try
                {
                    ChangerRepasMenu(repasChoisis, menuAChanger);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("", "Modification impossible. Veuillez réessayer.");
                }
            }

            RemplirAssignationsRepas(menuAChanger);
            return View(menuAChanger);
        }

        void ChangerRepasMenu(string[] repasChoisis, CMenu menuAChanger)
        {
            if (repasChoisis == null)
            {
                menuAChanger.m_Repas = new List<CRepas>();
                return;
            }

            var repasChoisisHS = new HashSet<string>(repasChoisis);
            var repasMenu = new HashSet<int>(menuAChanger.m_Repas.Select(r => r.m_iRepasId));

            foreach (var repas in db.Repas)
            {
                if (repasChoisisHS.Contains(repas.m_iRepasId.ToString()))
                {
                    if (!repasMenu.Contains(repas.m_iRepasId))
                    {
                        menuAChanger.m_Repas.Add(repas);
                    }
                }
                else
                {
                    if (repasMenu.Contains(repas.m_iRepasId))
                    {
                        menuAChanger.m_Repas.Remove(repas);
                    }
                }
            }
        }

        // GET: Menus/Delete/5
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

        // POST: Menus/Delete/5
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
