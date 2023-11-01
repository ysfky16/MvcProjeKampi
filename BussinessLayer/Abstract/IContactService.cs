using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetContacts();
        void ContactAdd(Contact contact);
        void ContactRemove(Contact contact);
        void ContactUpdate(Contact contact);
        Contact GetById(int id);

    }
}
