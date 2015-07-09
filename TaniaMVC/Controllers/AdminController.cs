using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TaniaMVC.Filters;
using TaniaMVC.Models;

namespace TaniaMVC.Controllers
{
    [InitializeSimpleMembership]  
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private TaniaEntitiesContainer db = new TaniaEntitiesContainer();    

        [Authorize(Roles="Administrador")]
        public ActionResult Index()
        {
            ViewBag.Lconteo = Convert.ToString(contadorVisitas.GetNumberVisitor(), 10);
            var userRoles = Roles.Provider;
            var userName = userRoles.GetUsersInRole("Usuario");
            ViewBag.countUser = userName.Count();
            ViewBag.carreras = db.Estadisticas.Count();
            return View();
        }
    }
}
