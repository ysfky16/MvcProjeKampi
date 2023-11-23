using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using Entitiy.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage

        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            string mail = (string)Session["WriterMail"];
            var messageList = messageManager.MessageListInbox(mail);
            return View(messageList);
        }
        public ActionResult SendBox()
        {
            string mail = (string)Session["WriterMail"];
            var messageList = messageManager.MessageListSendBox(mail);
            return View(messageList);
        }

        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {

            message.SenderMail = (string)Session["WriterMail"];
            ValidationResult results = messageValidator.Validate(message);

            if (results.IsValid)
            {
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

        [HttpPost]
        public ActionResult MessageCancel()
        {
            return RedirectToAction("Inbox");
        }


        [HttpPost]
        public ActionResult MessageDraft(Message message)
        {
            message.SenderMail = (string)Session["WriterMail"];
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

        public ActionResult MessageDetails(int id)
        {
            var messageValues = messageManager.GetById(id);
            return View(messageValues);
        }

        public PartialViewResult WriterPanelMessageSideBar()
        {
            string mail = (string)Session["WriterMail"];

            //var contactValues = contactManager.GetContacts();
            var messageInboxValues = messageManager.MessageListInbox(mail);
            var messageSendboxValues = messageManager.MessageListSendBox(mail);
            //ViewBag.MailCount = contactValues.Count;
            ViewBag.InboxMailCount = messageInboxValues.Count;
            ViewBag.SendboxMailCount = messageSendboxValues.Count;
            return PartialView();
        }
    }
}