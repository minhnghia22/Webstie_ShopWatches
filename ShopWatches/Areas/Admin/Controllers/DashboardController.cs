using ShopWatches.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopWatches.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        [CustomAuthorizeAttribute(Role = "Admin")]
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}