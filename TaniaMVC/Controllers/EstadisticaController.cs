using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaniaMVC.Controllers
{
    public class EstadisticaController : Controller
    {
        //
        // GET: /Estadistica/
        private TaniaEntitiesContainer db = new TaniaEntitiesContainer();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Agregar()
        {
            Estadistica estadistica = new Estadistica();
            return View(estadistica);
        }
        [HttpPost]
        public ActionResult Agregar(Estadistica estadistica)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Estadisticas.Add(estadistica);
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
