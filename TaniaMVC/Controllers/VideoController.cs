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
    public class VideoController : Controller
    {
        //
        // GET: /Video/

        private TaniaEntitiesContainer db = new TaniaEntitiesContainer();
        //
        // GET: /Logro/
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View(db.Videos.ToList());
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult Agregar()
        {
            Video video = new Video();
            return View(video);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Agregar(Video video)
        {
            video.url = video.url.Replace("watch", "embed");
            try
            {
                if (ModelState.IsValid)
                {
                    db.Videos.Add(video);
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
            Video video = db.Videos.Find(id);
            return View(video);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Editar(Video video)
        {
            video.url = video.url.Replace("watch", "embed");
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(video).State = EntityState.Modified;
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
                Video video = db.Videos.Find(id);
                db.Videos.Remove(video);
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
