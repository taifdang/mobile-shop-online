using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MobileShopOnline.Models;
using System.IO;


namespace MobileShopOnline.Areas.Admin.Controllers
{
    public class AdminProductsController : Controller
    {
        private MobileShopOnlineEntities db = new MobileShopOnlineEntities();

        // GET: Admin/AdminProducts
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);
            return View(products.ToList());
        }

        // GET: Admin/AdminProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/AdminProducts/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Admin/AdminProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase ImgProd1, HttpPostedFileBase ImgProd2,HttpPostedFileBase ImgProd3)
        {
            if (ModelState.IsValid)
            {
                if (ImgProd1 != null)
                {
                    var fileName = Path.GetFileName(ImgProd1.FileName);
                    var path = Path.Combine(Server.MapPath("~/image"), fileName);
                    product.Image1 = fileName;
                    ImgProd1.SaveAs(path);
                }

                if (ImgProd2 != null)
                {
                    var fileName = Path.GetFileName(ImgProd2.FileName);
                    var path = Path.Combine(Server.MapPath("~/image"), fileName);
                    product.Image2 = fileName;
                    ImgProd2.SaveAs(path);
                }

                if (ImgProd3 != null)
                {
                    var fileName = Path.GetFileName(ImgProd1.FileName);
                    var path = Path.Combine(Server.MapPath("~/image"), fileName);
                    product.Image3 = fileName;
                    ImgProd3.SaveAs(path);

                }

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Admin/AdminProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // POST: Admin/AdminProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,IntialPrice,Price,CategoryID,Image1,Image2,Image3,amount,ProductIntroduction,Chipset,Ram,Memory,ScreenSize,OS,Camera,Pin,Resolution")] Product product, HttpPostedFileBase ImgProd1, HttpPostedFileBase ImgProd2, HttpPostedFileBase ImgProd3)
        {
            if (ModelState.IsValid)
            {
                if (ImgProd1 != null)
                {
                    var fileName = Path.GetFileName(ImgProd1.FileName);
                    var path = Path.Combine(Server.MapPath("~/image"), fileName);
                    product.Image1 = fileName;
                    ImgProd1.SaveAs(path);
                }

                if (ImgProd2 != null)
                {
                    var fileName = Path.GetFileName(ImgProd2.FileName);
                    var path = Path.Combine(Server.MapPath("~/image"), fileName);
                    product.Image2 = fileName;
                    ImgProd2.SaveAs(path);
                }

                if (ImgProd3 != null)
                {
                    var fileName = Path.GetFileName(ImgProd1.FileName);
                    var path = Path.Combine(Server.MapPath("~/image"), fileName);
                    product.Image3 = fileName;
                    ImgProd3.SaveAs(path);

                }

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Admin/AdminProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/AdminProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
