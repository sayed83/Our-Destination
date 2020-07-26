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
    public class Payment_DetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Payment_Details
        public ActionResult Index()
        {
            var payment_Details = db.Payment_Details.Include(p => p.MemberPaymentType).Include(p => p.Month).Include(p => p.Payment_Master);
            return View(payment_Details.ToList());
        }

        // GET: Payment_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment_Details payment_Details = db.Payment_Details.Find(id);
            if (payment_Details == null)
            {
                return HttpNotFound();
            }
            return View(payment_Details);
        }

        // GET: Payment_Details/Create
        public ActionResult Create()
        {
            ViewBag.PaymentTypeId = new SelectList(db.MemberPaymentType, "PaymentTypeId", "PaymentType");
            ViewBag.MonthId = new SelectList(db.Month, "MonthId", "MonthName");
            ViewBag.PaymentMasterId = new SelectList(db.Payment_Master, "PaymentMasterId", "AddedBy");
            return View();
        }

        // POST: Payment_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentDetailsId,PaymentTypeId,MonthId,PaymentDate,PaymentAmount,TotalAmount,NetAmount,GivenYear,AddedBy,UpdatedBy,AddedDate,UpdateDate,userid,comid,PaymentMasterId")] Payment_Details payment_Details)
        {
            if (ModelState.IsValid)
            {
                db.Payment_Details.Add(payment_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PaymentTypeId = new SelectList(db.MemberPaymentType, "PaymentTypeId", "PaymentType", payment_Details.PaymentTypeId);
            ViewBag.MonthId = new SelectList(db.Month, "MonthId", "MonthName", payment_Details.MonthId);
            ViewBag.PaymentMasterId = new SelectList(db.Payment_Master, "PaymentMasterId", "AddedBy", payment_Details.PaymentMasterId);
            return View(payment_Details);
        }

        // GET: Payment_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment_Details payment_Details = db.Payment_Details.Find(id);
            if (payment_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.PaymentTypeId = new SelectList(db.MemberPaymentType, "PaymentTypeId", "PaymentType", payment_Details.PaymentTypeId);
            ViewBag.MonthId = new SelectList(db.Month, "MonthId", "MonthName", payment_Details.MonthId);
            ViewBag.PaymentMasterId = new SelectList(db.Payment_Master, "PaymentMasterId", "AddedBy", payment_Details.PaymentMasterId);
            return View(payment_Details);
        }

        // POST: Payment_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentDetailsId,PaymentTypeId,MonthId,PaymentDate,PaymentAmount,TotalAmount,NetAmount,GivenYear,AddedBy,UpdatedBy,AddedDate,UpdateDate,userid,comid,PaymentMasterId")] Payment_Details payment_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PaymentTypeId = new SelectList(db.MemberPaymentType, "PaymentTypeId", "PaymentType", payment_Details.PaymentTypeId);
            ViewBag.MonthId = new SelectList(db.Month, "MonthId", "MonthName", payment_Details.MonthId);
            ViewBag.PaymentMasterId = new SelectList(db.Payment_Master, "PaymentMasterId", "AddedBy", payment_Details.PaymentMasterId);
            return View(payment_Details);
        }

        // GET: Payment_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment_Details payment_Details = db.Payment_Details.Find(id);
            if (payment_Details == null)
            {
                return HttpNotFound();
            }
            return View(payment_Details);
        }

        // POST: Payment_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment_Details payment_Details = db.Payment_Details.Find(id);
            db.Payment_Details.Remove(payment_Details);
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
