using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccesoDatos.Models;
using TaniaMVC.Models;
using System.Net.Mail;

namespace TaniaMVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private TaniaEntitiesContainer db = new TaniaEntitiesContainer();

        [AllowAnonymous]
        public ActionResult Index()
        {
            contadorVisitas.CountNewVisitor();
            return View();
        }
        [AllowAnonymous]
        public ActionResult _Portada()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult _About()
        {
            return View(db.Abouts.ToList());
        }
        [AllowAnonymous]
        public ActionResult _Experiencia()
        {
            return View(db.Habilidades.ToList());
        }
        [AllowAnonymous]
        public ActionResult _Logros()
        {
            return View(db.Logros.OrderBy(m => m.fecha).Take(10).ToList());
        }
        [AllowAnonymous]
        public ActionResult _Portafolio()
        {
            ViewBag.categorias = db.Categorias.ToList();
            return View(db.Fotos.ToList());
        }
        [AllowAnonymous]
        public ActionResult _Eventos()
        {
            var eventos = db.Eventos.ToList();
            int i = eventos.Count;
            List<Evento> ultimos = new List<Evento>();
            if (i > 3)
            {
                for (int j = 1; j <= 3; j++)
                {
                    ultimos.Add(eventos[i - j]);
                }
                return View(ultimos);
            }
            else
            {
                return View(eventos);
            }
        }

        [AllowAnonymous]
        public ActionResult _Auspiciadores()
        {
            var auspiciadores = db.Auspiciadores.ToList();
            return View(auspiciadores);
        }
        [AllowAnonymous]
        public ActionResult _Contacto()
        {
            Correo correo = new Correo();
            return View(correo);
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult _Contacto(Correo correo)
        {
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add("josorese@alumnos.utalca.cl"); // correo de destino!
                mail.From = new MailAddress(correo.From);
                mail.Subject = correo.Subject;
                string Body = correo.Body;
                mail.Body = Body + ". " + Environment.NewLine + "Mail: " + correo.From;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("webtania.contacto@gmail.com", "webtania");// Sender email, correo solo para enviar.
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            //
            //
            //

        }
        public ActionResult _AllEventos()
        {
            var eventos = db.Eventos.ToList();
            return View(eventos);

        }
        public ActionResult _EventoModal(int id)
        {
            Evento evento = db.Eventos.Find(id);
            return View(evento);

        }
    }
}
