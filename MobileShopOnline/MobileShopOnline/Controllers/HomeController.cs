using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileShopOnline.Models;

namespace MobileShopOnline.Controllers
{
    public class HomeController : Controller
    {
        private MobileShopOnlineEntities db = new MobileShopOnlineEntities();
        public ActionResult Index()
        {
            
            ViewBag.CategoriesList = db.Categories.ToList();
            ViewBag.ProductsList = (from item in db.Products orderby item.ProductID descending select item).ToList().Take(10);

            int firstCate = db.Categories.First().CategoryID;
            int secondCate = db.Categories.FirstOrDefault(c => c.CategoryID != firstCate).CategoryID;

            ViewBag.FirstCate = db.Categories.FirstOrDefault(c => c.CategoryID == firstCate);
            ViewBag.SecondCate = db.Categories.FirstOrDefault(c => c.CategoryID == secondCate);

            ViewBag.ProductsList_1 = db.Products.Where(p => p.CategoryID == firstCate).ToList().Take(10);
            ViewBag.ProductsList_2 = db.Products.Where(p => p.CategoryID == secondCate).ToList().Take(10);

            return View();
        }
    }
}