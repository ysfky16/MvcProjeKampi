using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imageDal;

        public ImageFileManager(IImageFileDal imageDal)
        {
            _imageDal = imageDal;
        }

        public ImageFile GetById(int id)
        {
            return _imageDal.Get(x => x.ImageId == id);
        }

        public List<ImageFile> GetImageFile()
        {
            return _imageDal.GetAll();
        }
    }
}
