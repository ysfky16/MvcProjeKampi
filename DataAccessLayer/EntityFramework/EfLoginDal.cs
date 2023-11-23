using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repostories;
using Entitiy.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfLoginDal : GenericRepostory<Admin>, ILoginDal
    {
    }
}
