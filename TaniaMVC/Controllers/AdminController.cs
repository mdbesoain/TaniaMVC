using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaniaMVC.Models;

namespace TaniaMVC.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        [Authorize(Roles="Administrador")]
        public ActionResult Index()
        {
            ViewBag.Lconteo = Convert.ToString(contadorVisitas.GetNumberVisitor(), 10);
            return View();
        }
    }
}
