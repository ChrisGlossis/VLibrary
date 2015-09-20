using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Library.Models;

namespace Library.Controllers
{
    public class AdminPanelController : Controller
    {

        // GET: AdminPanel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageRoles()
        {
           return View();
        }

        public ActionResult RolesList()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roles = context.Roles.ToList();
            return View(roles); 
        }

        public ActionResult ManageUserRole()
        {
            return View();
        }
    }

}