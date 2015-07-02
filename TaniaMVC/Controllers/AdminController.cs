using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using TaniaMVC.Filters;
using TaniaMVC.Models;
using System.Web.Profile;

namespace TaniaMVC.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        [Authorize(Roles="Administrador")]
        public ActionResult Index()
        {
            //var user = ProfileManager.GetAllProfiles(ProfileAuthenticationOption.Authenticated);
            var userRoles = Roles.Provider;
            var userName = userRoles.GetUsersInRole("Usuario");
            ViewBag.countUser = userName.Count();
            return View();
        }
    }
}
