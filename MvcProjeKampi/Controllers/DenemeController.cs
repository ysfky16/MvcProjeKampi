﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class DenemeController : Controller
    {
        // GET: Deneme
        public ActionResult Test()
        {
            return View();
        }

        public ActionResult SweetAlert()
        {
            return View();
        }
    }
}