using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repostories;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfHeadingDal : GenericRepostory<Heading>, IHeadingDal
    {
 

    }
}
