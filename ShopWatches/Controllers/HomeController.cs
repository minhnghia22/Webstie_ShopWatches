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
            var products = db.Product.Where(p=> p.quantities > 1).OrderByDescending(p => p.ID);
            return View(products.ToList());        
        }
        
        public ActionResult Menu()
        {
            var products = db.Product.Include(p => p.Suppliers).Where(p => p.quantities > 1).OrderByDescending(p => p.ID);
            ViewBag.Cate= db.Categories.ToList();
            return View(products.ToList());
        }

        public ActionResult About()
        {
           
            return View();
        }

        public ActionResult Login()
        {
           
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Cart()
        {
            var products = db.Product.Include(p => p.Suppliers);
            return View(products.ToList());
        }


        // GET: Home/Details/5
        public ActionResult product_details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            var allPicture = db.Picture.Where(pic => pic.productID == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.listPic = allPicture;
            return View(product);
        }
        [HttpGet]
        public ActionResult search(string name)
        {
            var product = db.Product.Where(p => p.name.Contains(name)).ToList();
            return View(product);
        }

        [HttpPost]
        public ActionResult searchs(int price1, int price2)
        {
            var product = db.Product.Where(p => p.price >= price1 && p.price <= price2).ToList();
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
