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
    public class CartsController : Controller
    {
        private ShopWatchesDbContext db = new ShopWatchesDbContext();
       
        // GET: Cart
        public ActionResult Index()
        {

            if (Session["customerLogin"] == null)
            {
                return RedirectToAction("../Home/Index");
            }
            Customer cus = (Customer)Session["customerLogin"];
            var Cart = db.Cart.Include(c => c.Customer).Include(c => c.Product).Where(c => c.customerID == cus.IDCtm ).OrderByDescending(c => c.ID); ;
            return View(Cart.ToList());
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart c = db.Cart.Find(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            db.Cart.Remove(c);
            db.SaveChanges();          
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UpdateCart(FormCollection fc)
        {
            Customer cus = (Customer)Session["customerLogin"];
            string[] quantitys = fc.GetValues("quantity");
            var Cart = db.Cart.Where(c => c.customerID == cus.IDCtm).ToList();
            for (int i = 0; i < Cart.Count(); i++)
            {
                Cart[i].quantities = Convert.ToInt32(quantitys[i]);
                db.Entry(Cart[i]).State = EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult addtoCart(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Session["customerLogin"] == null)
            {
                return RedirectToAction("../Account/Login");
            }
            Customer c = (Customer)Session["customerLogin"];
            if(db.Cart.Where(x => x.customerID == c.IDCtm && x.ProductID == id).Count() > 0)
            {
                return RedirectToAction("Index");
            }
            Cart ct = new Cart();
            ct.customerID = c.IDCtm;
            ct.ProductID = id;
            ct.quantities = 1;
            db.Cart.Add(ct);
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Checkout() 
        {
            if (Session["customerLogin"] == null)
            {
                return RedirectToAction("../Home/Index");

            }
            return View();
        }
        [HttpPost]
        public ActionResult CheckCode(String code)
        {
            if (Session["customerLogin"] == null)
            {
                return RedirectToAction("../Home/Index");

            }
            Voucher v = db.Voucher.Where(x => x.code == code && x.status == "false").FirstOrDefault();
            if(v != null)
            {
                Session["voucher"] = v;
                v.status = "true";
                db.Entry(v).State = EntityState.Modified;
                Session["mess"] = "Your bill has been reduced "+v.value+"$.";
                db.SaveChanges();
            }
            else
            {
                Session["voucher"] = null;
                Session["mess"] = "The code is not correct! Please try another code.";
            }
            return RedirectToAction("Checkout");
        }
        public ActionResult BillPay()
        {
            if (Session["customerLogin"] == null)
            {
                return RedirectToAction("../Home/Index");

            }
            float total = 0;
            Customer cus = (Customer)Session["customerLogin"];
            Voucher v = (Voucher) Session["voucher"];
            var Cart = db.Cart.Include(c => c.Customer).Include(c => c.Product).Where(c => c.customerID == cus.IDCtm).ToList();
            foreach (var item in Cart)
            {
                total += (float)(item.quantities * item.Product.price);
            }
            
            //insert order
            Orders o = new Orders();
            o.customerID = cus.IDCtm;
            o.employeeID = 1;
            o.requested = DateTime.Now;
            o.discount = 0;
            if (v != null) { 
            o.totalMoney = total - v.value;
            o.discount = (int?)v.value;
            }
            else
            {
                o.totalMoney = total;
            }
            o.statusPayment = "Paymented";
            o.statusOrder = "Pending";
            db.Orders.Add(o);
            db.SaveChanges();
            //insert order details
            int ido = db.Orders.Max(x => x.ID);
            foreach (var item in Cart)
            {
                Orders_Details od = new Orders_Details();
                od.OrderID = ido;
                od.ProductID = item.ProductID;
                od.price = (float?)item.Product.price;
                od.quantities = item.quantities;
                //xu ly tru số lượng của sản phẩm sau khi bán ra
                Product p = db.Product.Find(item.ProductID);
                p.quantities -= item.quantities;
                //thay doi
                db.Entry(p).State = EntityState.Modified; 
                db.Orders_Details.Add(od);
            }
            db.SaveChanges();
           // Delete Cart
            foreach (var item in Cart)
            {
                db.Cart.Remove(item);
            }
            Session["voucher"] = null;
            db.SaveChanges();

            return View();
    
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
