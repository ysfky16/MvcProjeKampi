using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        void HeadingAdd(Heading heading);
        void HeadingRemove(Heading heading);
        void HeadingUpdate(Heading heading);
        Heading GetById(int id);

    }
}
