using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repostories;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class CategoryManager 
    {
        GenericRepostory<Category> repostory = new GenericRepostory<Category>();

        public List<Category> GetAllCategory()
        {
            return repostory.GetAll();
        }

        public void AddCategory(Category p)
        {
            if (p.CategoryName == "" || p.CategoryName.Length<3 || p.CategoryName.Length >=50)
            {
                // hata mesajı
            }
            else
            {
                repostory.Insert(p);
            }
        }
    }   
}
