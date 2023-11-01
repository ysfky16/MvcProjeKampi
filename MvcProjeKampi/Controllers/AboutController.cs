using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        // GET: About

        AboutManager manager = new AboutManager(new EfAboutDal());
        AboutValidator aboutValidator = new AboutValidator();
        public ActionResult Index()           
        {
            var aboutValue = manager.GetAbout();
            return View(aboutValue);
        }

        public ActionResult AddAbout() 
        {
        
            return View();
        
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            ValidationResult validationResults = aboutValidator.Validate(about);

            if (validationResults.IsValid)
            {
                manager.AboutAdd(about);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var result in validationResults.Errors)
                {
                    ModelState.AddModelError(result.PropertyName, result.ErrorMessage);
                }

            }

            return RedirectToAction("AboutPartial",about);


        }

        public PartialViewResult AboutPartial(About about)
        {

            return PartialView(about);
        }


    }
}