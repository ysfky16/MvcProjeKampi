using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Cantact

        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactValidator validationRules = new ContactValidator();
        public ActionResult Index()
        {
            var contactValues = contactManager.GetContacts();
            return View(contactValues);
        }


        public ActionResult GetMessageDetails(int id) 
        {
            var contactDetails = contactManager.GetById(id);
            return View(contactDetails);
        
        }

        public PartialViewResult ContactSideBar()
        {
            var contactValues = contactManager.GetContacts();
            var messageInboxValues = messageManager.MessageListInbox();
            var messageSendboxValues = messageManager.MessageListSendBox();
            ViewBag.MailCount = contactValues.Count;
            ViewBag.InboxMailCount = messageInboxValues.Count;
            ViewBag.SendboxMailCount = messageSendboxValues.Count;
            return PartialView();
        }
    }
}