using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopWatches.Models;

namespace ShopWatches.Controllers
{
    public class HomeController : Controller
    {
        private ShopWatchesDbContext db = new ShopWatchesDbContext();

        // GET: Home
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Supplier);
            return View(products.ToList());
        }

        public ActionResult Menu()
        {
            var products = db.Products.Include(p => p.Supplier);
            ViewBag.Cate= db.Categories.ToList();
            return View(products.ToList());
        }

        public ActionResult About()
        {
            var products = db.Products.Include(p => p.Supplier);
            return View(products.ToList());
        }

        public ActionResult Login()
        {
            var products = db.Products.Include(p => p.Supplier);
            return View(products.ToList());
        }

        public ActionResult Cart()
        {
            var products = db.Products.Include(p => p.Supplier);
            return View(products.ToList());
        }

        public ActionResult Register()
        {
            var products = db.Products.Include(p => p.Supplier);
            return View(products.ToList());
        }
        // GET: Home/Details/5
        public ActionResult product_details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            var allPicture = db.Pictures.Where(pic => pic.productID == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.listPic = allPicture;
            return View(product);
        }

        

        // GET: Home/Create
        public ActionResult Create()
        {
            ViewBag.SupplierID = new SelectList(db.Suppliers, "IDSup", "nameSup");
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SupplierID,name,quantities,warrantyTime,originName,img,detail,status,price")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupplierID = new SelectList(db.Suppliers, "IDSup", "nameSup", product.SupplierID);
            return View(product);
        }

        // GET: Home/Edit/5
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
            ViewBag.SupplierID = new SelectList(db.Suppliers, "IDSup", "nameSup", product.SupplierID);
            return View(product);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SupplierID,name,quantities,warrantyTime,originName,img,detail,status,price")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SupplierID = new SelectList(db.Suppliers, "IDSup", "nameSup", product.SupplierID);
            return View(product);
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
