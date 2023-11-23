using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entitiy.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class LoginManager : ILoginService
    {
        ILoginDal _loginDal;

        public LoginManager(ILoginDal loginDal)
        {
            _loginDal = loginDal;
        }

        public void AdminAdd(Admin admin)
        {
            _loginDal.Insert(admin);
        }

        public void AdminRemove(Admin admin)
        {
            _loginDal.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _loginDal.Update(admin);
        }

        public Admin GetById(int id)
        {
            return _loginDal.Get(x => x.AdminId == id);
        }

    }
}
