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
    public class CategoriaController : Controller
    {
        //
        // GET: /Categoria/

        private TaniaEntitiesContainer db = new TaniaEntitiesContainer();
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View(db.Categorias.ToList());
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult Agregar()
        {
            Categoria categoria = new Categoria();
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Agregar(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Categorias.Add(categoria);
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
            Categoria categoria = db.Categorias.Find(id);
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Editar(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(categoria).State = EntityState.Modified;
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
                Categoria categoria = db.Categorias.Find(id);
                db.Categorias.Remove(categoria);
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
