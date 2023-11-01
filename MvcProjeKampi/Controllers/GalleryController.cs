using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery

        ImageFileManager ImageFileManager = new ImageFileManager(new EfImageDal());
        public ActionResult Index()
        {
            var imageValues = ImageFileManager.GetImageFile();
            return View(imageValues);
        }
    }
}