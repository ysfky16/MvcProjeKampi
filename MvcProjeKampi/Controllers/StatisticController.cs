using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        Context db = new Context();
        public ActionResult Index()
        {
            ViewBag.KategoriSayisi = _categoryManager.GetCategories().Count();
            ViewBag.YazilimBaslik = db.Headings.Where(x => x.CategoryId == 14).Count();
            ViewBag.YazarAdi = db.Writers.Where(x=>x.WriterName.Contains("a")).Count();
            List<int> sayilar = db.Headings.Select(x => x.CategoryId).ToList();           // en çok başlık bulunan categori adını yazdr
            Dictionary<int, int> Dsayilar = sayilar
                .GroupBy(item => item)
                .ToDictionary(item => item.Key, item => item.Count());
            var encok = Dsayilar.Values.Max();

            ViewBag.Fark = (_categoryManager.GetCategories().Where(x => x.CategoryStatus == true).Count()) - (_categoryManager.GetCategories().Where(x => x.CategoryStatus == false).Count());
            return View();
        }
    }
}