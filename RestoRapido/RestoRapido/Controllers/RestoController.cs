using RestoRapido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestoRapido.Controllers
{
    public class Resto : Controller
    {
        private RestoContext db = new RestoContext();
    }
}