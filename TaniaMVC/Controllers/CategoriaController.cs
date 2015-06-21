using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaniaMVC.Controllers
{
    public class CategoriaController : Controller
    {
        //
        // GET: /Categoria/

        private TaniaEntitiesContainer db = new TaniaEntitiesContainer();

        public ActionResult Index()
        {
            return View(db.Categorias.ToList());
        }

        public ActionResult Agregar()
        {
            Categoria categoria = new Categoria();
            return View(categoria);
        }

        [HttpPost]
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
                return RedirectToAction("Index");
            }
        }


        public ActionResult Editar(int id)
        {
            Categoria categoria = db.Categorias.Find(id);
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                return RedirectToAction("Index");
            }
        }

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
