using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestoRapido.Models;

namespace RestoRapido.Controllers
{
    public class HomeController : Controller
    {
        private CRestoContext db = new CRestoContext();

        public ActionResult Index()
        {
            var Utilisateurs = db.Utilisateurs.ToList();

            //vider la variable de session sur l'arriver sur la page d'accueil
            Session["Prenom"] = null;
            Session["Type"] = null;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}