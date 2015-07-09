using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccesoDatos.Models;
using TaniaMVC.Models;
using System.Net.Mail;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;
using TaniaMVC.Filters;
using System.Net.Mime;
using System.Web.Security;


namespace TaniaMVC.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class ReporteController : Controller
    {
        //
        // GET: /Reporte/
        private TaniaEntitiesContainer db = new TaniaEntitiesContainer();
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View(db.Reportes.ToList());
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult Enviar_Correo(int id)
        {
            Correo correo = new Correo();
            ViewBag.id_reporte = id;
            return View(correo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Enviar_Correo(Correo correo, int id)
        {
            Reporte reporte = db.Reportes.Find(id);

            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.Attachments.Add(new Attachment(@reporte.url));
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
        [Authorize(Roles = "Administrador")]
        public ActionResult Crear()
        {
            Reporte reporte = new Reporte();
            reporte.reporte_id = db.Reportes.Count() + 1;
            return View(reporte);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Crear(FormCollection form, Reporte reporte)
        {
            
            List<Columna> columnas = new List<Columna>();
            for (int i = 0; i < form.Count-2; i += 4)
            {
                Columna columna = new Columna();
                columna.fecha = form[i];
                columna.detalle = form[i+1];
                columna.num_boleta = form[i+2];
                columna.costo = Int32.Parse(form[i+3]);
                columnas.Add(columna);
            }

            //string file = @"C:\Users\juancarlosgonzalezca\Documents\Documento.pdf";

            string path = AppDomain.CurrentDomain.BaseDirectory;
            string file = path + "/Reportes/" + reporte.reporte_id + ".pdf";

            ViewBag.Columnas = columnas;

            reporte.url = file;

            try
            {
                if (ModelState.IsValid)
                {
                    db.Reportes.Add(reporte);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Error");
            }

            string html;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(this.ControllerContext, "PDF");
                var viewContext = new ViewContext(this.ControllerContext, viewResult.View, this.ViewData, this.TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(this.ControllerContext, viewResult.View);
                html= sw.GetStringBuilder().ToString();
            }

            Document document = new Document(PageSize.A4, 80, 50, 30, 65);
            PdfWriter.GetInstance(document, new FileStream(file, FileMode.Create));
            document.Open();

            foreach (IElement E in HTMLWorker.ParseToList(new StringReader(html), new StyleSheet()))
                document.Add(E);

            document.Close();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult PDF(List<Columna> datos)
        {
            ViewBag.Columnas = datos;
            return View();
        }
        [Authorize(Roles = "Administrador")]
        public FileResult verPdf(int id)
        {
            Reporte reporte = db.Reportes.Find(id);
            return File(reporte.url, "application/pdf");
        }

        public ActionResult EnvioMasivo(Evento evento)
        {
            MailMessage mail = new MailMessage();
            var userRoles = Roles.Provider;
            var userName = userRoles.GetUsersInRole("Usuario");

            string emails = "";
            int i = 0;
            foreach (string correo in userName)
            {
                if (i == 0)
                {
                    emails = correo;
                }
                else
                {
                    emails = correo + "," + emails;
                }
                i += 1;
            }

            mail.To.Add(emails); // correo de destino!
            mail.From = new MailAddress("webtania.contacto@gmail.com");
            mail.Subject = evento.nombre + " " + evento.fecha;

            string html = "<h2>Tania González te invita a:</h2>" + "<img src='cid:imagen' />" +
                          "<h3>Visita mi página Web: http://grupoe-001-site1.smarterasp.net</h3>";

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, MediaTypeNames.Text.Html);

            // Creamos el recurso a incrustar. Observad
            // que el ID que le asignamos (arbitrario) está
            // referenciado desde el código HTML como origen
            // de la imagen (resaltado en amarillo)...

            string path = AppDomain.CurrentDomain.BaseDirectory;

            LinkedResource img = new LinkedResource(path + evento.url_flayer, MediaTypeNames.Image.Jpeg);
            img.ContentId = "imagen";

            // Lo incrustamos en la vista HTML...

            htmlView.LinkedResources.Add(img);

            // Por último, vinculamos ambas vistas al mensaje...

            mail.AlternateViews.Add(htmlView);


            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
            ("webtania.contacto@gmail.com", "webtania");// Sender email, correo solo para enviar.
            smtp.EnableSsl = true;
            smtp.Send(mail);

            return RedirectToAction("Index", "Evento");
        }

    }

    

}
