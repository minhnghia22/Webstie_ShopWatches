using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopWatches.Common;
using ShopWatches.Library;
using ShopWatches.Models;

namespace ShopWatches.Areas.Admin.Controllers
{
    public class PicturesController : Controller
    {
        private ShopWatchesDbContext db = new ShopWatchesDbContext();


        [CustomAuthorizeAttribute(Role = "Admin")]
        // GET: Admin/Pictures
        public ActionResult Index()
        {
            var pictures = db.Pictures.Include(p => p.Product);
            return View(pictures.ToList());
        }

        public ActionResult Search(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pictures = db.Pictures.Where(pic => pic.productID == id).ToList();
            return View(pictures.ToList());
        }

        // GET: Admin/Pictures/Create
        public ActionResult Create()
        {
            ViewBag.productID = new SelectList(db.Products, "ID", "name");
            return View();
        }

        // POST: Admin/Pictures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Picture picture)
        {
            ViewBag.productID = new SelectList(db.Products, "ID", "name");
            if (db.Pictures.Where(pic => pic.url == picture.url && pic.productID  == picture.productID).Count() > 0)
            {
                Product p = db.Products.Find(picture.productID);
                Message.set_flash("Picture has belongs to " + p.name+"", "danger");
                return View(picture);
            }
            if (ModelState.IsValid)
            {
                db.Pictures.Add(picture);
                db.SaveChanges();
                Message.set_flash("Add successed", "success");
                return RedirectToAction("Index");
            }
            Message.set_flash("Add failed", "danger");
            
            return View(picture);
        }

        // GET: Admin/Pictures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            ViewBag.productID = new SelectList(db.Products, "ID", "name", picture.productID);
            return View(picture);
        }

        // POST: Admin/Pictures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Picture picture)
        {
            ViewBag.productID = new SelectList(db.Products, "ID", "name", picture.productID);

            if (ModelState.IsValid)
            {
                db.Entry(picture).State = EntityState.Modified;
                db.SaveChanges();
                Message.set_flash("Edit successed", "success");
                return RedirectToAction("Index");
            }
            Message.set_flash("Edit failed", "danger");
            
            return View(picture);
        }

        // GET: Admin/Pictures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // POST: Admin/Pictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
                       
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            db.Pictures.Remove(picture);
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
