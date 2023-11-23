using Entitiy.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface ILoginService
    {
        void AdminAdd(Admin admin);
        void AdminRemove(Admin admin);
        void AdminUpdate(Admin admin);
        Admin GetById(int id);

    }
}
