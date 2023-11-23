using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
    public class HeadingController : Controller
    {
        HeadingManager manager = new HeadingManager(new EfHeadingDal());
        HeadingValidator headingValidator = new HeadingValidator();

        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());    // kategori nesnelerine ulaşabilmek için

        WriterManager writerManager = new WriterManager(new EfWriterDal());            // yazar nesnelerine ulaşabilmek için
        public ActionResult Index()
        {
            var headingValues = manager.GetList();
            return View(headingValues);
        }

        public ActionResult AddHeading()
        {
            List<SelectListItem> categoryValues = (from x in categoryManager.GetCategories()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString(),

                                                   }).ToList();

            List<SelectListItem> writerValues = (from x in writerManager.GetWriters()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.WriterName +" " + x.WriterSurmame,
                                                       Value = x.WriterId.ToString(),

                                                   }).ToList();

            ViewBag.CategoryValues = categoryValues;
            ViewBag.WriterValues = writerValues;
            //ViewBag.WriterValues2 = new SelectList(writerManager.GetWriters(), "WriterId", "WriterName");
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            ValidationResult validationResults = headingValidator.Validate(heading);

            if (validationResults.IsValid)
            {
                heading.HeadingDate = DateTime.Now;
                manager.HeadingAdd(heading);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in validationResults.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                List<SelectListItem> categoryValues = (from x in categoryManager.GetCategories()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryId.ToString(),

                                                       }).ToList();

                List<SelectListItem> writerValues = (from x in writerManager.GetWriters()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.WriterName + " " + x.WriterSurmame,
                                                         Value = x.WriterId.ToString(),

                                                     }).ToList();

                ViewBag.CategoryValues = categoryValues;
                ViewBag.WriterValues = writerValues;
            }
            return View(heading);
        }

        public ActionResult EditHeading(int id) 
        {
            List<SelectListItem> categoryValues = (from x in categoryManager.GetCategories()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString(),

                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;

            var headingValue = manager.GetById(id);
        
            return View(headingValue);
        
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            ValidationResult validationResults = headingValidator.Validate(heading);



            if (validationResults.IsValid)
            {

                manager.HeadingUpdate(heading);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var error in validationResults.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                List<SelectListItem> categoryValues = (from x in categoryManager.GetCategories()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryId.ToString(),

                                                       }).ToList();

                ViewBag.CategoryValues = categoryValues;

            }




            return View(heading);

        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = manager.GetById(id);
            if (headingValue.HeadingStatus)
            {
                headingValue.HeadingStatus = false;
            }
            else
            {
                headingValue.HeadingStatus = true;
            }

            manager.HeadingRemove(headingValue);
            return RedirectToAction("Index");

        }


    }
}