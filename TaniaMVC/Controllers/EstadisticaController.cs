using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaniaMVC.Filters;

namespace TaniaMVC.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class EstadisticaController : Controller
    {
        //
        // GET: /Estadistica/
        private TaniaEntitiesContainer db = new TaniaEntitiesContainer();
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View(db.Estadisticas.ToList());
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult Agregar(int id)
        {
            Estadistica estadistica = new Estadistica();
            Evento evento = db.Eventos.Find(id);
            estadistica.Evento = evento;
            return View(estadistica);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Agregar(Estadistica estadistica, int id)
        {
            Evento evento = db.Eventos.Find(id);
            estadistica.Evento = evento;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Estadisticas.Add(estadistica);
                    db.SaveChanges();

                    evento = estadistica.Evento;
                    evento.Estadistica = estadistica;
                    db.Entry(evento).State = EntityState.Modified;
                    db.SaveChanges();

                }
                return RedirectToAction("Index", "Evento", null);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Error");
            }
        }
    }
}
