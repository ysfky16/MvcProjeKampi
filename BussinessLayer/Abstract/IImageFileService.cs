using Entitiy.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IImageFileService
    {

        List<ImageFile> GetImageFile();
        ImageFile GetById(int id);
    }
}
