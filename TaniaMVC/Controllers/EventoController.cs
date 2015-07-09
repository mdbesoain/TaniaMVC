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
    public class EventoController : Controller
    {
        //
        // GET: /Evento/
        private TaniaEntitiesContainer db = new TaniaEntitiesContainer();    
        public ActionResult Index()
        {
            return View(db.Eventos.ToList());
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Agregar()
        {
            Evento evento = new Evento();
            ViewBag.Disciplinas = new SelectList(db.Disciplinas, "id_disciplina", "nombre");
            return View(evento);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Agregar(Evento evento, HttpPostedFileBase file, int Disciplinas)
        {
            Disciplina disciplina = db.Disciplinas.Find(Disciplinas);
            evento.Disciplina = disciplina;
            evento.url_flayer = "vacio";
            try
            {
                if (ModelState.IsValid)
                {
                    db.Eventos.Add(evento);
                    db.SaveChanges();
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string filePath = path + "/Images/Subidas/" + evento.id_evento + ".jpg";
                    evento.url_flayer = "/Images/Subidas/" + evento.id_evento + ".jpg";
                    file.SaveAs(filePath);

                    db.Entry(evento).State = EntityState.Modified;
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
            Evento evento= db.Eventos.Find(id);
            ViewBag.Disciplinas = new SelectList(db.Disciplinas, "id_disciplina", "nombre");
            return View(evento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Editar(Evento evento, int Disciplinas)
        {
            Disciplina disciplina = db.Disciplinas.Find(Disciplinas);
            evento.Disciplina = disciplina;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(evento).State = EntityState.Modified;
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
                Evento evento = db.Eventos.Find(id);
                db.Eventos.Remove(evento);
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
