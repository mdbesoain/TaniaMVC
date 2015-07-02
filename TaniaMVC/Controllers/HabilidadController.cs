using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaniaMVC.Controllers
{
    public class HabilidadController : Controller
    {
        //
        // GET: /Habilidad/
        private TaniaEntitiesContainer db = new TaniaEntitiesContainer();

        public ActionResult Index()
        {
            return View(db.Habilidades.ToList());
        }

        public ActionResult Agregar()
        {
            Habilidad habilidad = new  Habilidad();
            return View(habilidad);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Habilidad habilidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Habilidades.Add(habilidad);
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
           Habilidad habilidad = db.Habilidades.Find(id);
            return View(habilidad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Habilidad habilidad)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(habilidad).State = EntityState.Modified;
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
                Habilidad habilidad = db.Habilidades.Find(id);
                db.Habilidades.Remove(habilidad);
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
