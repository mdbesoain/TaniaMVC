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
    public class HabilidadController : Controller
    {
        //
        // GET: /Habilidad/
        private TaniaEntitiesContainer db = new TaniaEntitiesContainer();
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View(db.Habilidades.ToList());
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult Agregar()
        {
            Habilidad habilidad = new  Habilidad();
            return View(habilidad);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
        public ActionResult Editar(int id)
        {
           Habilidad habilidad = db.Habilidades.Find(id);
            return View(habilidad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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
