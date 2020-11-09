using ShopWatches.Library;
using ShopWatches.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopWatches.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        ShopWatchesDbContext db = new ShopWatchesDbContext();
        // GET: Admin/Auth
        public ActionResult login()
        {
            if (Session["userLogin"] != null) {
              Response.Redirect("~/Admin/Products/Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult login(String email, String password)
        {
            if (Session["userLogin"] != null)
            {
                Response.Redirect("~/Admin/Products/Index");
            }
            if (ModelState.IsValid)
            {
                String Email = email;
                string Pass = Mystring.ToMD5(password);
                var userC = db.Employees.Where(m => m.emailEmp == Email && m.passwordEmp == Pass);
                if (userC.Count() == 0)
                {
                    ViewBag.error = "Email or Password Incorrect";
                    return View();
                }
                userC = db.Employees.Where(m => m.emailEmp == Email && m.passwordEmp == Pass && m.Role.name == "Admin");
                if (userC.Count() == 0)
                {
                    ViewBag.error = "You do not have permission to login";
                    return View();
                }
                else
                {
                    Employee user = userC.First();
                    Session["userLogin"] = user;
                    Response.Redirect("~/Admin/products");
                }
            }
            return View("login");
            
        }
        public ActionResult logout()
        {
            Session.Remove("userLogin");
            Response.Redirect("~/Admin");
            return View();
        }









    }
}
