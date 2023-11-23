using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListByHeadingId(int id);
        List<Content> GetListByWriter(int id);
        void ContentAdd(Content content);
        void ContentRemove(Content content);
        void ContentUpdate(Content content);
        Content GetById(int id);

    }
}
