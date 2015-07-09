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
    public class AuspiciadorController : Controller
    {
        private TaniaEntitiesContainer db = new TaniaEntitiesContainer();

        //
        // GET: /Auspiciador/
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View(db.Auspiciadores.ToList());
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult Agregar()
        {
            Auspiciador auspiciador = new Auspiciador();
            return View(auspiciador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Agregar(Auspiciador auspiciador, HttpPostedFileBase file)
        {
            
            auspiciador.url_logo= "vacio";
            try
            {
                if (ModelState.IsValid)
                {
                    db.Auspiciadores.Add(auspiciador);
                    db.SaveChanges();
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string filePath = path + "/Images/auspiciadores/" + auspiciador.id_auspiciador+ ".jpg";
                    auspiciador.url_logo = "/Images/auspiciadores/" + auspiciador.id_auspiciador + ".jpg";
                    file.SaveAs(filePath);
                    db.Entry(auspiciador).State = EntityState.Modified;
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
            Auspiciador auspiciador = db.Auspiciadores.Find(id);
            return View(auspiciador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Editar(Auspiciador auspiciador)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(auspiciador).State = EntityState.Modified;
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
                Auspiciador auspiciador = db.Auspiciadores.Find(id);
                db.Auspiciadores.Remove(auspiciador);
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
