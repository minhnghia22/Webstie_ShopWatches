using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopWatches.Common;
using ShopWatches.Models;

namespace ShopWatches.Areas.Admin.Controllers
{
   
    public class Categories_ProductController : Controller
    {
        private ShopWatchesDbContext db = new ShopWatchesDbContext();



        [CustomAuthorizeAttribute(Role = "Admin")]
        // GET: Admin/Categories_Product
        public ActionResult Index()
        {
            var categories_Product = db.Categories_Product.Include(c => c.Category).Include(c => c.Product);
            return View(categories_Product.ToList());
        }

        // GET: Admin/Categories_Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories_Product categories_Product = db.Categories_Product.Find(id);
            if (categories_Product == null)
            {
                return HttpNotFound();
            }
            return View(categories_Product);
        }

        // GET: Admin/Categories_Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoriesID = new SelectList(db.Categories, "ID", "name");
            ViewBag.ProductID = new SelectList(db.Products, "ID", "name");
            return View();
        }

        // POST: Admin/Categories_Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categories_Product categories_Product)
        {
            if (ModelState.IsValid)
            {
                db.Categories_Product.Add(categories_Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriesID = new SelectList(db.Categories, "ID", "name", categories_Product.CategoriesID);
            ViewBag.ProductID = new SelectList(db.Products, "ID", "name", categories_Product.ProductID);
            return View(categories_Product);
        }

        // GET: Admin/Categories_Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories_Product categories_Product = db.Categories_Product.Find(id);
            if (categories_Product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriesID = new SelectList(db.Categories, "ID", "name", categories_Product.CategoriesID);
            ViewBag.ProductID = new SelectList(db.Products, "ID", "name", categories_Product.ProductID);
            return View(categories_Product);
        }

        // POST: Admin/Categories_Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categories_Product categories_Product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categories_Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriesID = new SelectList(db.Categories, "ID", "name", categories_Product.CategoriesID);
            ViewBag.ProductID = new SelectList(db.Products, "ID", "name", categories_Product.ProductID);
            return View(categories_Product);
        }

        // GET: Admin/Categories_Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories_Product categories_Product = db.Categories_Product.Find(id);
            if (categories_Product == null)
            {
                return HttpNotFound();
            }
            return View(categories_Product);
        }

        // POST: Admin/Categories_Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categories_Product categories_Product = db.Categories_Product.Find(id);
            db.Categories_Product.Remove(categories_Product);
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
