using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization

        public static List<SelectListItem> _roles = new List<SelectListItem>()
        {
            new SelectListItem{Text="A",Value="A"},
            new SelectListItem{Text="B",Value="B"},
            new SelectListItem{Text="C",Value="C"},
            new SelectListItem{Text="D",Value="D"},
            new SelectListItem{Text="E",Value="E"}
        };

        AdminManager adminManager = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var values =adminManager.GetAdmin();
            return View(values);
        }

        public ActionResult AddAdmin()
        {
            ViewBag.Roles = _roles;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAdmin(Admin admin)
        {
            ViewBag.Roles = _roles;
            adminManager.AdminAdd(admin);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateAdmin(int id)
        {
            ViewBag.Roles = _roles;
            var admin = adminManager.GetById(id);
            return View(admin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateAdmin(Admin admin)
        {
            ViewBag.Roles = _roles;
            adminManager.AdminUpdate(admin);
            return RedirectToAction("Index");
        }
    }
}