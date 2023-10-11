using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repostories
{
    public class GenericRepostory<T> : IRepostory<T> where T : class
    {
        Context context = new Context();
        DbSet<T> _object;

        public GenericRepostory()                             // constructor
        {
            _object = context.Set<T>();                      // objeyi gönderdiğimiz obje olarak tanımladık
        }

        public void Delete(T p)
        {
            _object.Remove(p);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _object.ToList();
        }

        public List<T> IfList(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Insert(T p)
        {
            _object.Add(p);
            context.SaveChanges();
        }

        public void Update(T p)
        {
            context.SaveChanges();
        }
    }

}

