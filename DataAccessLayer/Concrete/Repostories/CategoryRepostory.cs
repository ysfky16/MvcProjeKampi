using DataAccessLayer.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repostories
{
    public class CategoryRepostory : ICategoryDal
    {
        Context c = new Context();

        DbSet<Category> categoryObject;
        public void Delete(Category p)
        {
            categoryObject.Remove(p);
            c.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return categoryObject.ToList();
        }

        public List<Category> IfList(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category p)
        {
            c.SaveChanges();
        }

        public void Insert(Category p)
        {
            categoryObject.Add(p);
            c.SaveChanges();
        }
    }
}
