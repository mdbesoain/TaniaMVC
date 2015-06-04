using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaniaMVC.Controllers
{
    public class DisciplinaController : Controller
    {
        private TaniaEntitiesContainer db = new TaniaEntitiesContainer();

        //
        // GET: /Disciplina/

        public ActionResult Index()
        {
            return View(db.Disciplinas.ToList());
        }

        public ActionResult Agregar()
        {
            Disciplina disciplina = new Disciplina();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Disciplina disciplina)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Disciplinas.Add(disciplina);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

    }
}
