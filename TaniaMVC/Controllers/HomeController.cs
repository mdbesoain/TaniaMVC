using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccesoDatos.Models;

namespace TaniaMVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private TaniaEntitiesContainer db = new TaniaEntitiesContainer();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Portada()
        {
            return View();
        }

        public ActionResult _About()
        {
            return View();
        }

        public ActionResult _Experiencia()
        {
            return View();
        }

        public ActionResult _Logros()
        {
            var logros = db.Logros.Where(x => x.id_logro > 0);
            return View(logros.ToList());
        }

        public ActionResult _Portafolio()
        {
            return View();
        }

        public ActionResult _Contacto()
        {
            return View();
        }
    }
}
