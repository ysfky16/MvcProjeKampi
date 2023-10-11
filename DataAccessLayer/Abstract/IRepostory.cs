using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepostory<T>
    {
        List<T> GetAll();
        void Insert(T p);
        void Update(T p);
        void Delete(T p);

        List<T> IfList(Expression<Func<T, bool>> filter);

    }
}
