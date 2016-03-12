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
            Session.Clear();

            return View();
        }
    }
}