using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OurDestination.Models;

namespace OurDestination.Controllers
{
    public class MonthlyPaymentSetupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MonthlyPaymentSetups
        public ActionResult Index()
        {
            var monthlyPaymentSetup = db.MonthlyPaymentSetup.Include(m => m.Department).Include(m => m.Month);
            return View(monthlyPaymentSetup.ToList());
        }

        // GET: MonthlyPaymentSetups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyPaymentSetup monthlyPaymentSetup = db.MonthlyPaymentSetup.Find(id);
            if (monthlyPaymentSetup == null)
            {
                return HttpNotFound();
            }
            return View(monthlyPaymentSetup);
        }

        // GET: MonthlyPaymentSetups/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName");
            ViewBag.MonthId = new SelectList(db.Month, "MonthId", "MonthName");
            return View();
        }

        // POST: MonthlyPaymentSetups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentSetupId,DepartmentId,MonthId,Total,Year")] MonthlyPaymentSetup monthlyPaymentSetup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (monthlyPaymentSetup.PaymentSetupId > 0)
                    {
                        db.Entry(monthlyPaymentSetup).State = EntityState.Modified;
                    }
                    else
                    {
                        db.MonthlyPaymentSetup.Add(monthlyPaymentSetup);
                    }
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName", monthlyPaymentSetup.DepartmentId);
                ViewBag.MonthId = new SelectList(db.Month, "MonthId", "MonthName", monthlyPaymentSetup.MonthId);
                return View(monthlyPaymentSetup);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // GET: MonthlyPaymentSetups/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Title = "Edit";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyPaymentSetup monthlyPaymentSetup = db.MonthlyPaymentSetup.Find(id);
            if (monthlyPaymentSetup == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName", monthlyPaymentSetup.DepartmentId);
            ViewBag.MonthId = new SelectList(db.Month, "MonthId", "MonthName", monthlyPaymentSetup.MonthId);
            return View("Create", monthlyPaymentSetup);
        }

        // POST: MonthlyPaymentSetups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentSetupId,DepartmentId,MonthId,Total,Year")] MonthlyPaymentSetup monthlyPaymentSetup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monthlyPaymentSetup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName", monthlyPaymentSetup.DepartmentId);
            ViewBag.MonthId = new SelectList(db.Month, "MonthId", "MonthName", monthlyPaymentSetup.MonthId);
            return View(monthlyPaymentSetup);
        }

        // GET: MonthlyPaymentSetups/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.Title = "Delete";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlyPaymentSetup monthlyPaymentSetup = db.MonthlyPaymentSetup.Find(id);
            if (monthlyPaymentSetup == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName", monthlyPaymentSetup.DepartmentId);
            ViewBag.MonthId = new SelectList(db.Month, "MonthId", "MonthName", monthlyPaymentSetup.MonthId);
            return View("Create", monthlyPaymentSetup);
        }

        // POST: MonthlyPaymentSetups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonthlyPaymentSetup monthlyPaymentSetup = db.MonthlyPaymentSetup.Find(id);
            db.MonthlyPaymentSetup.Remove(monthlyPaymentSetup);
            db.SaveChanges();
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
