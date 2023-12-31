﻿using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        void CategoryAdd(Category category);
        void CategoryRemove(Category category);
        void CategoryUpdate(Category category);
        Category GetById(int id);
    }
}
