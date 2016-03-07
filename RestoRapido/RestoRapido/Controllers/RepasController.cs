using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestoRapido.Models;
using System.Data.Entity.Infrastructure;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

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




        public ActionResult SelectionImage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


          // CRepas repas = db.Repas.Find(id);

            @Session["SpecialID"] = id;
         //   ViewBag.RepasID = Convert.ToInt32(id);

            return View();
        }

        public ActionResult FileUpload(HttpPostedFileBase file)
        {

            if (Session["SpecialID"] == null)
                return RedirectToAction("Login", "Account");


            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/App_Data/images"), pic);

                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\dbRestoRapidoV24.mdf;Initial Catalog=RestoRapido;Integrated Security=True"))
                {
                    string sql = "UPDATE CRepas SET m_imgImage = @image WHERE m_iRepasId = @RepId";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@image", file.FileName);
                        cmd.Parameters.AddWithValue("@RepId", Convert.ToInt32(Session["SpecialID"]));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }   


           //     int test = Convert.ToInt32(Session["SpecialID"]);


                /*
                byte[] imgData;

                using (BinaryReader reader = new BinaryReader(file.InputStream))
                {
                    imgData = reader.ReadBytes(Convert.ToInt32(file.InputStream.Length));
                }

                */


                /*
                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }*/

            }
            // after successfully uploading redirect the user
            return RedirectToAction("Index");
        }

    }
}
