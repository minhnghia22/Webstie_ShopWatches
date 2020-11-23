using ShopWatches.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopWatches.Controllers
{
    public class CartController
    {

        public ActionResult addProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addProduct(Cart c)
        {
            if (c.ID != null)
            {
                using (ShopWatchesDbContext db = new ShopWatchesDbContext())
                {

                    db.Carts.Add(c);
                    db.SaveChanges();
                }

            }
            return View();
        }



        // delete carrt
        public ActionResult deteleProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult deleteProduct(int id)
        {
            if ()
        }

    }
}