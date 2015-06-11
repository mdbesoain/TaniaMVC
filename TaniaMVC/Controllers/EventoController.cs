using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;


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
        public ActionResult Editar(int id)
        {
            Evento evento= db.Eventos.Find(id);
            return View(evento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Evento evento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(evento).State = EntityState.Modified;
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

        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Evento evento = db.Eventos.Find(id);
                db.Eventos.Remove(evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Error");
            }
        }
    }
}
