using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileShopOnline.Models;

namespace MobileShopOnline.Controllers
{
    public class CartController : Controller
    {
        MobileShopOnlineEntities db = new MobileShopOnlineEntities();
        // GET: Cart


        public List<CartItem> GetCart()
        {
            List<CartItem> myCart = Session["MyCart"] as List<CartItem>;

            //Nếu giỏ hàng chưa tồn tại thì tạo mới và đưa vào Session
            if (myCart == null)
            {
                myCart = new List<CartItem>();
                Session["MyCart"] = myCart;
            }
            return myCart;
        }


        public ActionResult AddToCart(FormCollection prod)
        {
            //Lấy giỏ hàng hiện tại
            List<CartItem> myCart = GetCart();

            int id = int.Parse(prod["ProductID"]);
            int quantity = int.Parse(prod["Quantity"]);

            CartItem currentProduct = myCart.FirstOrDefault(p => p.ProductID == id);
            if (currentProduct == null)
            {
                currentProduct = new CartItem(id);
                currentProduct.Number = quantity;
                myCart.Add(currentProduct);
            }
            else
            {
                currentProduct.Number += quantity; //Sản phẩm đã có trong giỏ thì tăng số lượng lên 
            }
            return RedirectToAction("GetCartInfo", "Cart");
        }

        public ActionResult RemoveProduct(int id)
        {
            List<CartItem> myCart = GetCart();
            CartItem currentProduct = myCart.FirstOrDefault(p => p.ProductID == id);
            myCart.Remove(currentProduct);
            return RedirectToAction("GetCartInfo", "Cart");
        }

        private int GetTotalNumber()
        {
            int totalNumber = 0;
            List<CartItem> myCart = GetCart();
            if (myCart != null)
                totalNumber = myCart.Sum(sp => sp.Number);
            return totalNumber;
        }

        private decimal GetTotalPrice()
        {
            decimal totalPrice = 0;
            List<CartItem> myCart = GetCart();
            if (myCart != null)
                totalPrice = myCart.Sum(sp => sp.FinalPrice());
            return totalPrice;
        }

        public ActionResult GetCartInfo()
        {
            List<CartItem> myCart = GetCart();
            //Nếu giỏ hàng trống thì trả về trang ban đầu
            if (myCart == null || myCart.Count == 0)
            {
                return RedirectToAction("EmpryCart", "Cart");
            }
            ViewBag.TotalNumber = GetTotalNumber();
            ViewBag.TotalPrice = GetTotalPrice();
            return View(myCart); //Trả về View hiển thị thông tin giỏ hàng
        }

        public ActionResult UpdateQuantity(FormCollection prod)
        {
            int id = int.Parse(prod["ProductID"]);
            int quantity = int.Parse(prod["Quantity"]);

            List<CartItem> myCart = GetCart();
            CartItem currentProduct = myCart.FirstOrDefault(p => p.ProductID == id);
            currentProduct.Number = quantity;
            return RedirectToAction("GetCartInfo", "Cart");
        }

        public ActionResult CartPartial()
        {
            ViewBag.TotalNumber = GetTotalNumber();
            
            return PartialView();
        }

        public ActionResult EmpryCart()
        {
            ViewBag.EmptyNotification = "Chưa có sản phẩm nào trong giỏ hàng";
            return View();
        }

        public ActionResult Payment()
        {
            List<CartItem> myCart = GetCart();

            ViewBag.TotalPrice = GetTotalPrice();

            return View(myCart);
        }

        public ActionResult Order(string addressOrder)
        {
            Order order = new Order();
            Customer cus = (Customer)Session["Account"];
            List<CartItem> myCart = GetCart();


            order.UserID = cus.UserID;
            order.PhoneNumber = cus.PhoneNumber;
            order.Address = addressOrder;
            order.DateOrder = DateTime.Now;
            order.StatusOrder = 0;
            order.QuantityProduct = GetTotalNumber();
            db.Orders.Add(order);
            db.SaveChanges();

            foreach (var item in myCart)
            {
                OrderDetail orderDetail = new OrderDetail();

                orderDetail.ProductID = item.ProductID;
                orderDetail.IdOrder = order.IdOrder;
                orderDetail.Quantity = item.Number;
                orderDetail.UnitPrice = item.Price;
                orderDetail.FinalPrice = item.FinalPrice();
                db.OrderDetails.Add(orderDetail);

                //var prod = db.Products.FirstOrDefault(p => p.ProductID == item.ProductID);
                //prod.amount -= 1;
            }    
            db.SaveChanges();
            Session["MyCart"] = null;
            return RedirectToAction("GetOrder/" + cus.UserID, "Order");
        }

       


    }
}