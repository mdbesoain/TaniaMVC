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
    public class PortafolioController : Controller
    {
        //
        // GET: /Portafolio/
        private TaniaEntitiesContainer db = new TaniaEntitiesContainer();
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View(db.Fotos.ToList());
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult Agregar()
        {
            Foto foto = new Foto();
            ViewBag.Categorias = new SelectList(db.Categorias, "id_categoria", "nombre");
            return View(foto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Agregar(Foto foto, int Categorias, HttpPostedFileBase file)
        {
            Categoria categoria = db.Categorias.Find(Categorias);
            foto.Categoria = categoria;
            foto.url = "vacia";
            try
            {
                if (ModelState.IsValid)
                {
                    db.Fotos.Add(foto);
                    db.SaveChanges();

                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string filePath = path + "/Images/portafolio/" + categoria.id_categoria + ".jpg";
                    file.SaveAs(filePath);
                    foto.url = "/Images/portafolio/" + categoria.id_categoria + ".jpg";
                    db.Entry(foto).State = EntityState.Modified;
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
            Foto foto = db.Fotos.Find(id);
            return View(foto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
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
                return View("Error");
            }
        }
        [Authorize(Roles = "Administrador")]
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

        public FileResult verFoto(int id)
        {
            Foto foto = db.Fotos.Find(id);
            return File(foto.url, "image/jpg");
        }

    }
}
