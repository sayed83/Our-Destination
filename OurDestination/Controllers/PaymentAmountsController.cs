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
    public class PaymentAmountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PaymentAmounts
        public ActionResult Index()
        {
            var paymentAmount = db.PaymentAmount.Include(p => p.Department).Include(p => p.Member);
            return View(paymentAmount.ToList());
        }

        // GET: PaymentAmounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentAmount paymentAmount = db.PaymentAmount.Find(id);
            if (paymentAmount == null)
            {
                return HttpNotFound();
            }
            return View(paymentAmount);
        }

        // GET: PaymentAmounts/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName");
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName");
            return View();
        }

        // POST: PaymentAmounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentAmountId,PaymentTypeId,MemberId,DepartmentId,Amount,Active,userid,comid")] PaymentAmount paymentAmount)
        {
            if (ModelState.IsValid)
            {
                db.PaymentAmount.Add(paymentAmount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName", paymentAmount.DepartmentId);
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", paymentAmount.MemberId);
            return View(paymentAmount);
        }

        // GET: PaymentAmounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentAmount paymentAmount = db.PaymentAmount.Find(id);
            if (paymentAmount == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName", paymentAmount.DepartmentId);
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", paymentAmount.MemberId);
            return View(paymentAmount);
        }

        // POST: PaymentAmounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentAmountId,PaymentTypeId,MemberId,DepartmentId,Amount,Active,userid,comid")] PaymentAmount paymentAmount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentAmount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName", paymentAmount.DepartmentId);
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", paymentAmount.MemberId);
            return View(paymentAmount);
        }

        // GET: PaymentAmounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentAmount paymentAmount = db.PaymentAmount.Find(id);
            if (paymentAmount == null)
            {
                return HttpNotFound();
            }
            return View(paymentAmount);
        }

        // POST: PaymentAmounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymentAmount paymentAmount = db.PaymentAmount.Find(id);
            db.PaymentAmount.Remove(paymentAmount);
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
