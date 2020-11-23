using ShopWatches.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace ShopWatches.Controllers
{
    public class CategoryController : Controller
    {
        private ShopWatchesDbContext db = new ShopWatchesDbContext();
        // GET: Categories
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cates = db.Categories_Product.Where(ca => ca.CategoriesID == id);
            if (cates == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.Cate = db.Categories.ToList();
            ViewBag.ID = id;
            return View(cates.ToList());
        }
    }
}