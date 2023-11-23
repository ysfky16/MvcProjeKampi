using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent

        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context(); 
        public ActionResult MyContent(string mail)
        {     
            mail =(string)Session["WriterMail"];
            int writerId = context.Writers.FirstOrDefault(x => x.WriterMail == mail).WriterId;
            var myContentValues = contentManager.GetListByWriter(writerId);
            return View(myContentValues);
        }

        public ActionResult AddContent(int id)
        {
            ViewBag.HeadingId = id;
            return View();

        }

        [HttpPost]  
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterMail"];
            int writerId = context.Writers.FirstOrDefault(x => x.WriterMail == mail).WriterId;
            content.ContentDate= DateTime.Now;
            content.WriterId = writerId;
            content.ContentStatus = true;
            contentManager.ContentAdd(content);
            return RedirectToAction("MyContent");

        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}