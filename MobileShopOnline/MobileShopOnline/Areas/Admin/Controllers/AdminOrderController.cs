using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileShopOnline.Models;

namespace MobileShopOnline.Areas.Admin.Controllers
{
    public class AdminOrderController : Controller
    {
        MobileShopOnlineEntities db = new MobileShopOnlineEntities();
        // GET: Admin/AdminOrder
        public ActionResult Index()
        {
            var orderList = (from order in db.Orders orderby order.IdOrder descending select order).ToList();   
            return View(orderList);
        }
        public ActionResult Details(int id)
        {
            var listProdOrder = db.OrderDetails.Where(order => order.IdOrder == id).ToList();
            decimal finalPrice = 0;
            foreach (var item in listProdOrder)
            {
                finalPrice += (decimal)item.FinalPrice;
            }
            ViewBag.FinalPrice = finalPrice;
            ViewBag.Address = db.Orders.FirstOrDefault(o => o.IdOrder == id).Address;
            ViewBag.Date = db.Orders.FirstOrDefault(o => o.IdOrder == id).DateOrder;
            ViewBag.Id = db.Orders.FirstOrDefault(o => o.IdOrder == id).IdOrder;
            ViewBag.Status = db.Orders.FirstOrDefault(o => o.IdOrder == id).StatusOrder;

            ViewBag.CusInfor = db.Orders.FirstOrDefault(o => o.IdOrder == id);

            return View(listProdOrder);
        }

        public ActionResult Confirm(int id)
        {
            var prodListOrder = db.OrderDetails.Where(o => o.IdOrder == id).ToList();
            foreach (var item in prodListOrder)
            {
                var product = db.Products.FirstOrDefault(p => p.ProductID == item.ProductID);
                product.amount -= item.Quantity;
                db.SaveChanges();
            }
            var order = db.Orders.FirstOrDefault(o => o.IdOrder == id);
            order.StatusOrder = 2;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}