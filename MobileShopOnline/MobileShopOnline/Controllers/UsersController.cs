using MobileShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace MobileShopOnline.Controllers
{
    public class UsersController : Controller
    {
        MobileShopOnlineEntities db = new MobileShopOnlineEntities();
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer cust)
        {
            if (ModelState.IsValid)
            {
                var adminAccount = db.AdminAccounts.FirstOrDefault(k => k.Email == cust.UserEmail && k.Password == cust.UserPassword);

                if (adminAccount != null)
                {
                    Session["Account"] = adminAccount;
                    return RedirectToAction("Index", "Admin/AdminHome");
                }
                var account = db.Customers.FirstOrDefault(k => k.UserEmail == cust.UserEmail && k.UserPassword == cust.UserPassword);
                if (account != null)
                {
                        Session["Account"] = account;
                        return RedirectToAction("Index", "Home");
                }
                else
                    ViewBag.ThongBao = "*Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
           
        }

        public ActionResult Logout()
        {
            Session["Account"] = null;
            Session["MyCart"] = null;
            return RedirectToAction("Login", "Users");
        }


        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Detail([Bind(Include = "UserID,UserName,UserEmail,PhoneNumber,UserPassword,AvatarImage")] Customer customer, HttpPostedFileBase ImageUser)
        {
            if (ModelState.IsValid)
            {
                if (ImageUser != null)
                {
                    //Lấy tên file của hình được up lên

                    var fileName = Path.GetFileName(ImageUser.FileName);

                    //Tạo đường dẫn tới file

                    var path = Path.Combine(Server.MapPath("~/image"), fileName);
                    //Lưu tên

                    customer.AvatarImage = fileName;
                    //Save vào Images Folder
                    ImageUser.SaveAs(path);

                }
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Detail","Users");
            }
            return View(customer);
        }


        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(FormCollection customer)
        {
            if(customer["userPassword"] != customer["rePassword"])
            {
                @ViewBag.Notification = "Mật khẩu xác nhận không chính xác";
                return View();
            }
            else
            {
                string email = customer["userEmail"].ToString();
                var cus = db.Customers.FirstOrDefault(k => k.UserEmail == email);
                if(cus != null)
                {
                    ViewBag.NotificationEmail = "Đã có người đăng ký bằng email này";
                    return View();
                }
                else
                {
                    Customer accout = new Customer();
                    accout.UserName = customer["userName"];
                    accout.UserEmail = customer["userEmail"];
                    accout.PhoneNumber = customer["phoneNumber"];
                    accout.UserPassword = customer["userPassword"];
                    accout.AvatarImage = "user.png";

                    db.Customers.Add(accout);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Users");
                }
            }
            
        }

        

    }
}