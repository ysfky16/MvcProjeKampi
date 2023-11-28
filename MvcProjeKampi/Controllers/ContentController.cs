using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content

        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult GetAllContent(string parametre)
        {
            
            //var values = context.Contents.ToList();
            var values = contentManager.GetList(parametre);

            if (parametre==null)
            {
                return View(contentManager.GetList(""));
            }
            return View(values.ToList());
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = contentManager.GetListByHeadingId(id);
            return View(contentValues);
        }

    }
}