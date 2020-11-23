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
        [ValidateAntiForgeryToken]//để ngăn chặn các cuộc tấn công giả mạo yêu cầu trên nhiều trang web
        // Register method
        public ActionResult Register(Customer cs)
        {
          
            if (ModelState.IsValid)
            {
                using(ShopWatchesDbContext db = new ShopWatchesDbContext())
                {
                    if(db.Customer.Any(x => x.emailCtm == cs.emailCtm))//check mail
                    {
                        ModelState.AddModelError("", "Email already exist.");
                        return View("Register", cs);
                    }else if(db.Customer.Any(x => x.phoneCtm == cs.phoneCtm))
                    {
                        ModelState.AddModelError("", "Number phone already exist.");
                        return View("Register", cs);
                    }
                    else
                    {
                        cs.passwordCtm = EncryptMD5Password(cs.passwordCtm);
                        cs.created_at = DateTime.Today;
                        db.Customer.Add(cs);
                        db.SaveChanges();
                    }
                    
                }
                
            }
            return RedirectToAction("Login");
        }

        // Update profile
        public ActionResult Update()
        {
            if (Session["customerLogin"] == null)
            {
                return RedirectToAction("../Home/Index");
            }
            Customer cs = (Customer) Session["customerLogin"];
            return View(cs);
        }  

        [HttpPost]
        public ActionResult Update(Customer cs)
        {
            if (Session["customerLogin"] == null)
            {
                return RedirectToAction("../Home/Index");
            }
            if (ModelState.IsValid)
            {
                using (ShopWatchesDbContext db = new ShopWatchesDbContext())
                {
                        db.Entry(cs).State = EntityState.Modified;
                        db.SaveChanges();
                        ModelState.AddModelError("", "Updated successful.");
                        Session["customerLogin"] = cs; // cap nhat ss
                        return View(cs);
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
        public ActionResult Login(String emailCtm, string passwordCtm)
        {
            using(ShopWatchesDbContext db = new ShopWatchesDbContext())
            {
                passwordCtm = EncryptMD5Password(passwordCtm);
                var user = db.Customer.FirstOrDefault(u => u.emailCtm == emailCtm && u.passwordCtm == passwordCtm);
                if(user != null)
                {
                    Session["customerLogin"] = user;
                    return RedirectToAction("../Home/Index");
                }
                else
                {
                    ViewBag.mess = "Username or Password is wrong.";
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