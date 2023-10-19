using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetWriters();
        void AddWriter(Writer writer);
        void RemoveWriter(Writer writer);
        void UpdateWriter(Writer writer);

        Writer GetById(int id);

    }
}
