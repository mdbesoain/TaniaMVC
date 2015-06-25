using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaniaMVC.Controllers
{
    public class PortafolioController : Controller
    {
        //
        // GET: /Portafolio/
        private TaniaEntitiesContainer db = new TaniaEntitiesContainer();

        public ActionResult Index()
        {
            return View(db.Fotos.ToList());
        }

        public ActionResult Agregar()
        {
            Foto foto = new Foto();
            ViewBag.Categorias = new SelectList(db.Categorias, "id_categoria", "nombre");
            return View(foto);
        }

        [HttpPost]
        public ActionResult Agregar(Foto foto, int Categorias)
        {
            Categoria categoria = db.Categorias.Find(Categorias);
            foto.Categoria = categoria;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Fotos.Add(foto);
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
            Foto foto = db.Fotos.Find(id);
            return View(foto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Foto foto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(foto).State = EntityState.Modified;
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
                Foto foto = db.Fotos.Find(id);
                db.Fotos.Remove(foto);
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
