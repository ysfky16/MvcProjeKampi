using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal() );
        WriterValidator writerValidator = new WriterValidator();
        public ActionResult Index()
        {
            var writerValues = writerManager.GetWriters();
            return View(writerValues);
        }

        public ActionResult AddWriter() 
        { 
            
            return View(); 
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            
            ValidationResult validationResults = writerValidator.Validate(writer);

            if (validationResults.IsValid)
            {
                //writerManager.AddWriter(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var result in validationResults.Errors)
                {
                    ModelState.AddModelError(result.PropertyName, result.ErrorMessage);
                }
            }

            return View();
        }

        public ActionResult EditWriter(int id)
        {
            var writerValue = writerManager.GetById(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {
            ValidationResult validationResults = writerValidator.Validate(writer);

            if (validationResults.IsValid)
            {
                writerManager.UpdateWriter(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var result in validationResults.Errors)
                {
                    ModelState.AddModelError(result.PropertyName, result.ErrorMessage);
                }
            }
            
            return View(writer);
        }
    }
}