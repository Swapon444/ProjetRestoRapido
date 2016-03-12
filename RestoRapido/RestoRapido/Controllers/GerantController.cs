using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestoRapido.Models;
using System.Security.Cryptography;

namespace RestoRapido.Controllers
{
    public class GerantController : Controller
    {
        private CRestoContext db = new CRestoContext();

        public ActionResult Index()
        {
            if (@Session["Type"] != null)
                if (@Session["Type"].ToString() == "Gerant")
                    return View();

            return View("../Home/Index");
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
