﻿using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default

        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Headings()
        {
            var headingsValues = headingManager.GetList();
            return View(headingsValues);
        }
        public PartialViewResult Index(int id=0)
        {
            var contentValues = contentManager.GetListByHeadingId(id);   
            return PartialView(contentValues);
        }
    }
}