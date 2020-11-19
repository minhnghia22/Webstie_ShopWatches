using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopWatches.Common;
using ShopWatches.Library;
using ShopWatches.Models;

namespace ShopWatches.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {

        private ShopWatchesDbContext db = new ShopWatchesDbContext();


        // GET: Admin/Product

        [CustomAuthorizeAttribute(Role = "Admin")]
        public ActionResult Index()
        {
            var products = db.Product.Include(p => p.Suppliers);
           
            return View(products.ToList());
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.SupplierID = new SelectList(db.Suppliers, "IDSup", "nameSup");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Product product)
        {
            ViewBag.SupplierID = new SelectList(db.Suppliers, "IDSup", "nameSup");
            var check = db.Product.Where(p => p.name == product.name && p.SupplierID == product.SupplierID).Count();
            if(check > 0)
            {
                Message.set_flash("The product already exists", "danger");
                return View(product);
            }
            if (ModelState.IsValid)
            {
                // lấy tên loại sản phẩm
                product.name = product.name.Trim();
                db.Product.Add(product);
                db.SaveChanges();
                Message.set_flash("Add successed", "success");
                return RedirectToAction("Index");
            }
            Message.set_flash("Add failed", "danger");
            
            return View(product);
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupplierID = new SelectList(db.Suppliers, "IDSup", "nameSup", product.SupplierID);
            return View(product);
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            ViewBag.SupplierID = new SelectList(db.Suppliers, "IDSup", "nameSup");
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                Message.set_flash("Edit successed", "success");
                return RedirectToAction("Index");
            }
            Message.set_flash("Edit failed", "danger");

            return View(product);
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            var allPicture = db.Picture.Where(pic => pic.productID == id);
            foreach(var pic in allPicture)
            {
                db.Picture.Remove(pic);
            }
            db.Product.Remove(product);
         
            db.SaveChanges();
            Message.set_flash("Delete successed", "success");
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
