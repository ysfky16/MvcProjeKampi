using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entitiy.Concrete;
using Entity.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        WriterLoginManager writerLoginManager = new WriterLoginManager(new EfWriterDal());

        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Admin admin)
        {
            var adminInfo = context.Admins.FirstOrDefault(x=>x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
            if ( adminInfo!=null)
            {
                FormsAuthentication.SetAuthCookie(adminInfo.AdminUserName, false);
                Session["AdminUserName"] = adminInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }


            return View(admin);
        }

        public ActionResult WriterLogin()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {

            //var writerInfo = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
            var writerInfo = writerLoginManager.GetWriter(writer.WriterMail, writer.WriterPassword);
            if (writerInfo!=null)
            {
                FormsAuthentication.SetAuthCookie(writerInfo.WriterMail, false);
                Session["WriterMail"] = writerInfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }


            return View(writer);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}