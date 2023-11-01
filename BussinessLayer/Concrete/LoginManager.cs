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

        public void CategoryUpdate(Admin admin)
        {
            ;_loginDal.Update(admin);
        }

        public List<Admin> GetAdmin()
        {
            return _loginDal.GetAll();  
        }

        public Admin GetById(int id)
        {
            return _loginDal.Get(x => x.AdminId == id);
        }
    }
}
