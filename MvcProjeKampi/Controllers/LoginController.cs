using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using Entitiy.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        LoginManager loginManager = new LoginManager(new EfLoginDal());
        LoginValidator loginValidator = new LoginValidator();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Admin admin)
        {
            ValidationResult results = loginValidator.Validate(admin);

            if (results.IsValid)
            {
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            return View(admin);
        }
    }
}