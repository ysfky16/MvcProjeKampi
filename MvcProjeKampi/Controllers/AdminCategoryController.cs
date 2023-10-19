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
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory

        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var categoryValues = _categoryManager.GetCategories().OrderBy(x=>x.CategoryName).ToList();

            return View(categoryValues);

        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult results = validationRules.Validate(category);

            if (results.IsValid)
            {
                _categoryManager.CategoryAdd(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var result in results.Errors)
                {
                    ModelState.AddModelError(result.PropertyName, result.ErrorMessage);
                }
            }

            return View();
        }

        public ActionResult DeleteCategory(int id) 
        { 
            var categoryValue = _categoryManager.GetById(id);
            _categoryManager.CategoryRemove(categoryValue);
            return RedirectToAction("Index");

        }  

        public ActionResult EditCategory(int id)
        {
            var categoryValue = _categoryManager.GetById(id);

            return View(categoryValue);

        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {

            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult results = validationRules.Validate(category);

            if (results.IsValid)
            {
                _categoryManager.CategoryUpdate(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var result in results.Errors)
                {
                    ModelState.AddModelError(result.PropertyName, result.ErrorMessage);
                }
            }

            return View(category);

        }
    }
}