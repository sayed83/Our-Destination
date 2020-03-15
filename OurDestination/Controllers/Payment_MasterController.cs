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
    public class Payment_MasterController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Payment_Master
        public ActionResult Index()
        {
            var payment_Master = db.Payment_Master.Include(p => p.Department).Include(p => p.Member).Include(p => p.MemberPaymentType).Include(p => p.Month);
            return View(payment_Master.ToList());
        }

        // GET: Payment_Master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment_Master payment_Master = db.Payment_Master.Find(id);
            if (payment_Master == null)
            {
                return HttpNotFound();
            }
            return View(payment_Master);
        }

        // GET: Payment_Master/Create
        public ActionResult Create(int? paymentid)
        {
            ViewBag.PaymentMasterId = paymentid;
            if (paymentid == null)
            {
                paymentid = 0;
            }          
            else
            {
                List<Payment_Master> Pmaster = db.Payment_Master.Where(p => p.PaymentMasterId.ToString() == paymentid.ToString()).ToList();
                return View(Pmaster);
            }
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName");
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName");
            ViewBag.PaymentTypeId = new SelectList(db.MemberPaymentType, "PaymentTypeId", "PaymentType");
            ViewBag.MonthId = new SelectList(db.Month, "MonthId", "MonthName");
            ViewBag.Title = "Create";
            return View();
        }

        // POST: Payment_Master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentMasterId,PaymentTypeId,MemberId,DepartmentId,MonthId,PaymentDate,Amount,GivenYear,AddedBy,UpdatedBy,AddedDate,UpdateDate,Active,userid,comid")] Payment_Master payment_Master)
        {
            if (ModelState.IsValid)
            {
                db.Payment_Master.Add(payment_Master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName", payment_Master.DepartmentId);
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", payment_Master.MemberId);
            ViewBag.PaymentTypeId = new SelectList(db.MemberPaymentType, "PaymentTypeId", "PaymentType", payment_Master.PaymentTypeId);
            ViewBag.MonthId = new SelectList(db.Month, "MonthId", "MonthName", payment_Master.MonthId);
            return View(payment_Master);
        }

        // GET: Payment_Master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment_Master payment_Master = db.Payment_Master.Find(id);
            if (payment_Master == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName", payment_Master.DepartmentId);
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", payment_Master.MemberId);
            ViewBag.PaymentTypeId = new SelectList(db.MemberPaymentType, "PaymentTypeId", "PaymentType", payment_Master.PaymentTypeId);
            ViewBag.MonthId = new SelectList(db.Month, "MonthId", "MonthName", payment_Master.MonthId);
            return View(payment_Master);
        }

        // POST: Payment_Master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentMasterId,PaymentTypeId,MemberId,DepartmentId,MonthId,PaymentDate,Amount,GivenYear,AddedBy,UpdatedBy,AddedDate,UpdateDate,Active,userid,comid")] Payment_Master payment_Master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment_Master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName", payment_Master.DepartmentId);
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", payment_Master.MemberId);
            ViewBag.PaymentTypeId = new SelectList(db.MemberPaymentType, "PaymentTypeId", "PaymentType", payment_Master.PaymentTypeId);
            ViewBag.MonthId = new SelectList(db.Month, "MonthId", "MonthName", payment_Master.MonthId);
            return View(payment_Master);
        }

        // GET: Payment_Master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment_Master payment_Master = db.Payment_Master.Find(id);
            if (payment_Master == null)
            {
                return HttpNotFound();
            }
            return View(payment_Master);
        }

        // POST: Payment_Master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment_Master payment_Master = db.Payment_Master.Find(id);
            db.Payment_Master.Remove(payment_Master);
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
