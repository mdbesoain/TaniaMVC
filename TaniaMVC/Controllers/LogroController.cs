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
    public class LogroController : Controller
    {
        private TaniaEntitiesContainer db = new TaniaEntitiesContainer();
        //
        // GET: /Logro/
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View(db.Logros.ToList());
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult Agregar()
        {
            Logro logro = new Logro();
            return View(logro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Agregar(Logro logro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Logros.Add(logro);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Error");
            }
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult Editar(int id)
        {
            Logro logro = db.Logros.Find(id);
            return View(logro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Editar(Logro logro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(logro).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Error");
            }
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Logro logro = db.Logros.Find(id);
                db.Logros.Remove(logro);
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
