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
        List<Message> MessageListInbox();
        List<Message> MessageListSendBox();
        List<Message> MessageListDraftBox();
        List<Message> MessageListDeleteBox();
        void MessageAdd(Message message);
        void MessageDeleted(Message message);
        void MessageDraft(Message message);
        Message GetById(int id);
    }
}
