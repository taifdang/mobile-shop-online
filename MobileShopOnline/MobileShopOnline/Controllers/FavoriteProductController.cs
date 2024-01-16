using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileShopOnline.Models;

namespace MobileShopOnline.Controllers
{
    public class FavoriteProductController : Controller
    {
        MobileShopOnlineEntities db = new MobileShopOnlineEntities();
        // GET: FavoriteProduct
        
        public ActionResult FavoriteList(int id)
        {
            var product = db.FavoriteProducts.Where(n => n.UserID == id).ToList();

            ViewBag.ProductInfor = new List<Product>();
            foreach (var item in product)
            {
                Product prod = db.Products.FirstOrDefault(p => p.ProductID == item.ProductID);
                ViewBag.ProductInfor.Add(prod);
            }

            return View(product);
        }


        
        [HttpPost]
        public ActionResult InsertListFavorite(FavoriteProduct favoriteProd)
        {
            if (ModelState.IsValid)
            {
                var productAvail = db.FavoriteProducts.FirstOrDefault(p => p.ProductID == favoriteProd.ProductID && p.UserID == favoriteProd.UserID);
                if (productAvail != null)
                    return RedirectToAction("Index/" + favoriteProd.ProductID,"Details");
                else
                {

                    db.FavoriteProducts.Add(favoriteProd);
                    db.SaveChanges();

                    return RedirectToAction("FavoriteList/" + favoriteProd.UserID, "FavoriteProduct");
                }
            }
            return View("Index/" + favoriteProd.ProductID, "Details");
        }

        public ActionResult DeleteProduct(FavoriteProduct favoriteProd)
        {
            if (ModelState.IsValid)
            {
                var prod = db.FavoriteProducts.FirstOrDefault(p => p.ProductID == favoriteProd.ProductID && p.UserID == favoriteProd.UserID);
                db.FavoriteProducts.Remove(prod);
                db.SaveChanges();
            }
            return RedirectToAction("FavoriteList/" + favoriteProd.UserID, "FavoriteProduct");
        }
    }
}