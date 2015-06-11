﻿using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
            return View(disciplina);
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

        public ActionResult Editar(int id)
        {
            Disciplina disciplina = db.Disciplinas.Find(id);
            return View(disciplina);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Disciplina disciplina)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(disciplina).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
        }

        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Disciplina disciplina = db.Disciplinas.Find(id);
                db.Disciplinas.Remove(disciplina);
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
