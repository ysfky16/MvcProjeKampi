﻿using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(),JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> categoryClasses = new List<CategoryClass>();

            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 5

            });

            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Oyun",
                CategoryCount = 10

            });
            categoryClasses.Add(new CategoryClass()
            {
                CategoryName = "Bilim",
                CategoryCount = 3

            });

            return categoryClasses; 
        }
    }
}