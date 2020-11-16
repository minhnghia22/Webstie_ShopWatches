using ShopWatches.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopWatches.Controllers
{
    public class CartController
    {

        public boolean addProduct(Cart c)
        {
            if (c.ID1 != null)
            {
                using (ShopWatchesDbContext db = new ShopWatchesDbContext())
                {
                    

                }

            }
            return V
        }

        public boolean editProduct(Cart c)
        {

        }

    }
}