using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileShopOnline.Models;

namespace MobileShopOnline.Controllers
{
    public class CategoryController : Controller
    {
        private MobileShopOnlineEntities db = new MobileShopOnlineEntities();

        // GET: Category
        public ActionResult Index(int id)
        {
            var product = db.Products.Where(n => n.CategoryID == id).ToList();
            ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
            ViewBag.IdCategory = id;
            return View(product);
        }

        public ActionResult GetAllProduct()
        {
            var product = (from item in db.Products orderby item.ProductID descending select item).ToList();
            return View(product);
        }

      

        public ActionResult Search(string searchString)
        {
          
            var  result = db.Products.Where(s => s.ProductName.Contains(searchString)).ToList();
           
            return View(result);
        }





    }
}