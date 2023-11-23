using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public List<Message> MessageListDeleteBox(string mail)
        {
            return _messageDal.IfList(x => x.ReceiverMail == mail & x.IsDelete == true);
        }

        public List<Message> MessageListDraftBox(string mail)
        {
            return _messageDal.IfList(x => x.ReceiverMail == mail & x.IsDraft == true);
        }

        public List<Message> MessageListInbox(string mail)
        {
            return _messageDal.IfList(x => x.ReceiverMail == mail & x.IsDelete==false & x.IsDraft == false);
        }

        public List<Message> MessageListSendBox(string mail)
        {
            return _messageDal.IfList(x => x.SenderMail == mail & x.IsDelete == false & x.IsDraft == false);
        }

        public void MessageDeleted(Message message)
        {
            _messageDal.Update(message);
        }

        public void MessageDraft(Message message)
        {
            _messageDal.Insert(message);
        }
    }
}
