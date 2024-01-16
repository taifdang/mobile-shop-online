using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileShopOnline.Models;

namespace MobileShopOnline.Controllers
{
    public class OrderController : Controller
    {
        MobileShopOnlineEntities db = new MobileShopOnlineEntities();
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetOrder(int id)
        {
            var orderList = (from o in db.Orders orderby o.IdOrder descending where o.UserID == id select o).ToList();
            
            ViewBag.UserId = id;
            return View(orderList);
        }

        public ActionResult OrderDetail(int id)
        {
            var listProdOrder = db.OrderDetails.Where(p => p.IdOrder == id).ToList();
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

            ViewBag.Customer = db.Orders.FirstOrDefault(o => o.IdOrder == id);

            return View(listProdOrder);
        }

        public ActionResult CancelOrder(int id)
        {
            var order = db.Orders.FirstOrDefault(o => o.IdOrder == id);
            order.StatusOrder = 2;
            db.SaveChanges();

            int idUser = order.UserID.GetValueOrDefault();
            return RedirectToAction("GetOrder/" + idUser,"Order");
        }

       
    }
}