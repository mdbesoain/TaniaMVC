﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccesoDatos.Models;
using TaniaMVC.Models;
using System.Net.Mail;

namespace TaniaMVC.Controllers
{
    public class ReporteController : Controller
    {
        //
        // GET: /Reporte/

        public ActionResult Index()
        {
            Correo correo = new Correo();
            return View(correo);
        }

        [HttpPost]
        public ActionResult Index(Correo correo)
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
                return RedirectToAction("Index", "Reporte");
            }
            else
            {
                return RedirectToAction("Index", "Reporte");
            }
        }

    }
}
