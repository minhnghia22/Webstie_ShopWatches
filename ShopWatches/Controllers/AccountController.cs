using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopWatches.Models;

namespace ShopWatches.Controllers
{
    public class AccountController : Controller
    {
        //private ShopWatchesDbContext db = new ShopWatchesDbContext();
        // GET: Account
        
        // REGISTER
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]


        // Register 
        public ActionResult Register(Customer cs)
        {
          
            if (ModelState.IsValid)
            {
                using(ShopWatchesDbContext db = new ShopWatchesDbContext())
                {
                    if(db.Customers.Any(x => x.emailCtm == cs.emailCtm))
                    {
                        ModelState.AddModelError("", "Email already exist.");
                        return View("Register", cs);
                    }else if(db.Customers.Any(x => x.phoneCtm == cs.phoneCtm))
                    {
                        ModelState.AddModelError("", "Number phone already exist.");
                        return View("Register", cs);
                    }
                    else
                    {
                        cs.passwordCtm = EncryptMD5Password(cs.passwordCtm);
                        db.Customers.Add(cs);
                        db.SaveChanges();
                    }
                    
                }
                
            }
            return RedirectToAction("Login");
        }

        // Update profile
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(int id)
        {


            Customer cs = new Customer();
            if (ModelState.IsValid)
            {
                using (ShopWatchesDbContext db = new ShopWatchesDbContext())
                {

                    if (db.Customers.Any(x => x.phoneCtm == cs.phoneCtm))
                    {
                        ModelState.AddModelError("", "Number phone already exist.");
                        return View("Update", cs);
                    }
                    else
                    {
                        cs.passwordCtm = EncryptMD5Password(cs.passwordCtm);
                        var item = db.Customers.Where(x => x.IDCtm == id).First();
                        db.SaveChanges();
                        return View(item);

                    }

                }

            }
            return RedirectToAction("Update");
        }

        //LOGIN
        public ActionResult Login()
        {
            if(Session["nameCtm"] != null)
            {
                return RedirectToAction("../Home/Index");
            }

            return View();
        }


        [HttpPost]
        public ActionResult Login(Customer cs)
        {
            using(ShopWatchesDbContext db = new ShopWatchesDbContext())
            {
                cs.passwordCtm = EncryptMD5Password(cs.passwordCtm);
                var user = db.Customers.SingleOrDefault(u => u.emailCtm == cs.emailCtm && u.passwordCtm == cs.passwordCtm);
                if(user != null)
                {
                    Session["customerLogin"] = user;
                    return RedirectToAction("../Home/Index");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }
            }
            return View();
        }

        // logout
        public ActionResult Logout()
        {
            Session.Remove("customerLogin");
            
                return RedirectToAction("../Home/Index");            
        }


        // ma khoa password
        public string EncryptMD5Password(string pass)
        {
            using(MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(pass));
                return Convert.ToBase64String(data);

            }
        }

        


    }
}