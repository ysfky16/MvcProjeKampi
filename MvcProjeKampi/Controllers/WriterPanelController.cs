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
using PagedList;
using PagedList.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel

        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal()); 
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        HeadingValidator headingValidator = new HeadingValidator();
        Context context = new Context();
        int writerId;
        public ActionResult WriterProfile(int id =0)
        {
            string mail = (string)Session["WriterMail"];
            id = context.Writers.FirstOrDefault(x => x.WriterMail == mail).WriterId;
            var writerInfo = writerManager.GetById(id);
            return View(writerInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator validator = new WriterValidator();
            ValidationResult validationResult = validator.Validate(writer);

            if (validationResult.IsValid)
            {
                writerManager.UpdateWriter(writer);
                return RedirectToAction("WriterProfile");

            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(writer);
        }

        public ActionResult MyHeading(string mail)          
        {
            mail = (string)Session["WriterMail"];
            writerId = context.Writers.FirstOrDefault(x => x.WriterMail == mail).WriterId;
            var values = headingManager.GetListByWriter(writerId);
            return View(values);
        }

        public ActionResult AllHeading(int page=1)
        {
            var values = headingManager.GetList().ToPagedList(page,3);
            return View(values);
        }

        public ActionResult NewHeading()
        {
            List<SelectListItem> categoryValues = (from x in categoryManager.GetCategories()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString(),

                                                   }).ToList();

            ViewBag.CategoryValues = categoryValues;


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewHeading(Heading heading)
        {
            ValidationResult validationResults = headingValidator.Validate(heading);

            string mail = (string)Session["WriterMail"];
            writerId = context.Writers.FirstOrDefault(x => x.WriterMail == mail).WriterId;

            if (validationResults.IsValid)
            {
                heading.HeadingDate = DateTime.Now;
                heading.WriterId = writerId;
                heading.HeadingStatus = true;
                headingManager.HeadingAdd(heading);
                return RedirectToAction("MyHeading");
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

        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> categoryValues = (from x in categoryManager.GetCategories()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString(),

                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;

            var heading = headingManager.GetById(id);

            return View(heading);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditHeading(Heading heading)
        {
            ValidationResult validationResults = headingValidator.Validate(heading);

            if (validationResults.IsValid)
            {
                headingManager.HeadingUpdate(heading);
                return RedirectToAction("MyHeading");

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
            var headingValue = headingManager.GetById(id);
            if (headingValue.HeadingStatus)
            {
                headingValue.HeadingStatus = false;
            }
            else
            {
                headingValue.HeadingStatus = true;
            }

            headingManager.HeadingRemove(headingValue);
            return RedirectToAction("MyHeading");

        }
    }
}