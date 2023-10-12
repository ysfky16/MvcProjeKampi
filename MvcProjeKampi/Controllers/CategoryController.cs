using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category


        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList() 
        {
            var categoryValues = _categoryManager.GetCategories();

            return View(categoryValues);
        
        }   

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            //_categoryManager.AddCategory(p);
            return RedirectToAction("GetCategoryList");
        }
    }
}