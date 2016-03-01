using RestoRapido.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

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
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "m_iRepasId,m_strNom,m_iPrix,m_strDescription,m_boBle,m_boLait,m_boOeuf,m_boArachide,m_boSoja,m_boFruitCoque,m_boPoisson,m_boSesame,m_boCrustace,m_boMollusque")] CRepas cRepas)
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
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "m_iRepasId,m_strNom,m_iPrix,m_strDescription,m_boBle,m_boLait,m_boOeuf,m_boArachide,m_boSoja,m_boFruitCoque,m_boPoisson,m_boSesame,m_boCrustace,m_boMollusque")] CRepas cRepas)
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
