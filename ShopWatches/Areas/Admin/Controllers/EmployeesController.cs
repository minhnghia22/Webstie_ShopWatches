using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using ShopWatches.Common;
using ShopWatches.Library;
using ShopWatches.Models;

namespace ShopWatches.Areas.Admin.Controllers
{
    public class EmployeesController : Controller
    {
        private ShopWatchesDbContext db = new ShopWatchesDbContext();


        [CustomAuthorizeAttribute(Role = "Admin")]
        // GET: Admin/Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Role);
            return View(employees.ToList());
        }



        // GET: Admin/Employees/Create
        public ActionResult Create()
        {
            ViewBag.roleID = new SelectList(db.Roles, "ID", "name");
            return View();
        }

        // POST: Admin/Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            ViewBag.roleID = new SelectList(db.Roles, "ID", "name");
            if (db.Employees.Where(emp => emp.emailEmp == employee.emailEmp).Count() > 0)
            {
                Message.set_flash("The Email already exists", "danger");
                return View(employee);
            }
            if (db.Employees.Where(emp => emp.phoneEmp == employee.phoneEmp).Count() > 0)
            {
                Message.set_flash("The phone number already exists", "danger");
                return View(employee);
            }
            if (db.Employees.Where(emp => emp.IDcard == employee.IDcard).Count() > 0)
            {
                Message.set_flash("The ID Card already exists", "danger");
                return View(employee);
            }
            if (ModelState.IsValid)
            {
                employee.created_at = DateTime.Now;
                employee.passwordEmp = Mystring.ToMD5(employee.passwordEmp);
                db.Employees.Add(employee);
                db.SaveChanges();
                Message.set_flash("Add successed", "success");
                return RedirectToAction("Index");
            }

            ViewBag.roleID = new SelectList(db.Roles, "ID", "name", employee.roleID);
            Message.set_flash("Add failed", "danger");
            return View(employee);
        }

        // GET: Admin/Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.roleID = new SelectList(db.Roles, "ID", "name", employee.roleID);
            return View(employee);
        }

        // POST: Admin/Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
       
            ViewBag.roleID = new SelectList(db.Roles, "ID", "name");
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                Message.set_flash("Edit successed", "success");
                return RedirectToAction("Index");
            }
            Message.set_flash("Edit failed", "danger");
            return View(employee);
        }

        // GET: Admin/Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            
            db.Employees.Remove(employee);
            db.SaveChanges();
            Message.set_flash("Delete successed", "success");
            return RedirectToAction("Index");
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
