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
    public class OrdersController : Controller
    {
        private ShopWatchesDbContext db = new ShopWatchesDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            if (Session["customerLogin"] == null)
            {
                return RedirectToAction("../Home/Index");
            }
            Customer cus = (Customer)Session["customerLogin"];
            //var orders = db.Orders.Include(o => o.Customer).Include(o => o.Employee);
            var orders = db.Orders.Where(o => o.customerID == cus.IDCtm).Include(o => o.Customer);
            return View(orders.ToList());
        }

       
        public ActionResult Details(int? id)
        {
            if (Session["customerLogin"] == null)
            {
                return RedirectToAction("../Home/Index");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderdetail = db.Orders_Details.Where(od => od.OrderID == id).ToList();
            if (orderdetail == null)
            {
                return HttpNotFound();
            }
            return View(orderdetail);
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
