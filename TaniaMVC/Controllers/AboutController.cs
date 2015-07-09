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
    public class AboutController : Controller
    {
        //
        // GET: /About/
        private TaniaEntitiesContainer db = new TaniaEntitiesContainer();    

        public ActionResult Index()
        {
            return View(db.Abouts.ToList());
        }

        public ActionResult Agregar()
        {
            About about = new About();
            return View(about);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Agregar(About about)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Abouts.Add(about);
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
            About about = db.Abouts.Find(id);
            return View(about);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Editar(About about)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(about).State = EntityState.Modified;
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
                About about = db.Abouts.Find(id);
                db.Abouts.Remove(about);
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
