using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileShopOnline.Models;

namespace MobileShopOnline.Controllers
{
    public class FiltProductController : Controller
    {
        MobileShopOnlineEntities db = new MobileShopOnlineEntities();   
        // GET: FiltProduct
        public ActionResult Index()
        {
            return View();
        }

        //trên 4 củ
        public ActionResult Under4MilAllProduct(int id)
        {
            if (id == 0)
            {
                var products = (from item in db.Products orderby item.ProductID descending where item.Price <= 4000000 select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products);
            }
            else
            {
                var products = (from item in db.Products orderby item.ProductID descending where item.Price <= 4000000 && item.CategoryID == id select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products);
            }
        }

        //từ 4 củ tới 8 củ
        public ActionResult From4To8MilAllProduct(int id)
        {
            if (id == 0)
            {
                var products = (from item in db.Products orderby item.ProductID descending where item.Price >= 4000000 && item.Price <= 8000000 select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);

                ViewBag.IdCategory = id;

                return View(products);
            }
            else
            {
                var products = (from item in db.Products orderby item.ProductID descending where item.Price >= 4000000 && item.Price <= 8000000 && item.CategoryID == id select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);

                ViewBag.IdCategory = id;

                return View(products);
            }
        }
        //từ 8 củ tới 12 củ
        public ActionResult From8To12MilAllProduct(int id)
        {
            if (id == 0)
            {
                var products = (from item in db.Products orderby item.ProductID descending where item.Price >= 8000000 && item.Price <= 12000000 select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products);
            }
            else
            {
                var products = (from item in db.Products orderby item.ProductID descending where item.Price >= 8000000 && item.Price <= 12000000 && item.CategoryID == id select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products);
            }
        }
        //trên 12 củ
        public ActionResult Over12MilAllProduct(int id)
        {
            if (id == 0)
            {
                var products = (from item in db.Products orderby item.ProductID descending where item.Price >= 12000000 select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products);
            }
            else
            {
                var products = (from item in db.Products orderby item.ProductID descending where item.Price >= 12000000 && item.CategoryID == id select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products);
            }
        }


        //giá thấp -> cao
        public ActionResult IncreaseWithPrice(int id)
        {
            if (id == 0)
            {
                var products = (from item in db.Products orderby item.Price ascending select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products);
            }
            else
            {
                var products = (from item in db.Products orderby item.Price ascending where item.CategoryID == id select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products);
            }
        }


        //giá cao -> thấp
        public ActionResult DescreaseWithPrice(int id)
        {
            if (id == 0)
            {
                var products = (from item in db.Products orderby item.Price descending select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products);
            }
            else
            {
                var products = (from item in db.Products orderby item.Price descending where item.CategoryID == id select item).ToList();
                ViewBag.CategoryProd = db.Categories.FirstOrDefault(n => n.CategoryID == id);
                ViewBag.IdCategory = id;
                return View(products);
            }
        }
    }
}