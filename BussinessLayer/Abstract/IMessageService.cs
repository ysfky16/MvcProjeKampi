using Entitiy.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> MessageListInbox(string mail);
        List<Message> MessageListSendBox(string mail);
        List<Message> MessageListDraftBox(string mail);
        List<Message> MessageListDeleteBox(string mail);
        void MessageAdd(Message message);
        void MessageDeleted(Message message);
        void MessageDraft(Message message);
        Message GetById(int id);
    }
}
