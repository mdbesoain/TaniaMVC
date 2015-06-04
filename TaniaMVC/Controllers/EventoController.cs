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
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Evento evento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Eventos.Add(evento);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
