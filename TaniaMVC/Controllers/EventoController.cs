using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccesoDatos.Models;

namespace TaniaMVC.Controllers
{
    public class EventoController : Controller
    {
        //
        // GET: /Evento/
        private TaniaEntitiesContainer db = new TaniaEntitiesContainer();
        [Authorize(Roles="Administrador")]
        public ActionResult Index()
        {
            return View(db.Eventos.ToList());
        }

        public ActionResult Agregar()
        {
            Evento evento = new Evento();
            return View(evento);
        }
        [HttpPost]
        public ActionResult Agregar(Evento evento)
        {
            db.Eventos.Add(evento);
            return View();
        }

    }
}
