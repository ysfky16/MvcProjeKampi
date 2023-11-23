using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entitiy.Concrete;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message

        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        [Authorize(Roles ="A")]
        public ActionResult Inbox()
        {
            string mail = (string)Session["WriterMail"];
            var messageValues = messageManager.MessageListInbox(mail);    
            return View(messageValues);
        }

        public ActionResult Sendbox()
        {
            string mail = (string)Session["WriterMail"];
            var messageValues = messageManager.MessageListSendBox(mail);
            return View(messageValues);
        }

        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult results = messageValidator.Validate(message);

            if (results.IsValid)
            {
                message.SenderMail = "admin@gmail.com";
                message.MessageDate = DateTime.Now;
                messageManager.MessageAdd(message);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

            }

            return View();
        }

        public ActionResult MessageDetails(int id)
        {
            var messageValues = messageManager.GetById(id);
            return View(messageValues);
        }

        [HttpPost]
        public ActionResult MessageCancel()
        {
           return RedirectToAction("Inbox");
        }


        [HttpPost]
        public ActionResult MessageDraft(Message message)
        {
            message.SenderMail = "admin@gmail.com";
            ValidationResult results = messageValidator.Validate(message);

            if (results.IsValid)
            {
                message.IsDraft = true;
                message.MessageDate = DateTime.Now;
                messageManager.MessageDraft(message);
                return RedirectToAction("DraftBox");
            }
            else
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

            }

            return View("NewMessage");
        }
        public ActionResult DraftBox()
        {
            string mail = (string)Session["WriterMail"];
            var messageValues = messageManager.MessageListDraftBox(mail);
            return View(messageValues);
        }


        public ActionResult DeletedBox()
        {
            string mail = (string)Session["WriterMail"];
            var messageValues = messageManager.MessageListDeleteBox(mail);
            return View(messageValues);
        }
    }
}