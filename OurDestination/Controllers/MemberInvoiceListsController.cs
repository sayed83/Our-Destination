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
    public class MemberInvoiceListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MemberInvoiceLists
        public ActionResult Index()
        {
            var memberInvoiceList = db.MemberInvoiceList.Include(m => m.Member).Include(m => m.Month);
            return View(memberInvoiceList.ToList());
        }

        // GET: MemberInvoiceLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberInvoiceList memberInvoiceList = db.MemberInvoiceList.Find(id);
            if (memberInvoiceList == null)
            {
                return HttpNotFound();
            }
            return View(memberInvoiceList);
        }

        // GET: MemberInvoiceLists/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName");
            ViewBag.MonthId = new SelectList(db.Month, "MonthId", "MonthName");
            return View();
        }

        // POST: MemberInvoiceLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InvoiceNo,TotalAmount,PaidAmount,DueAmount,MemberId,CreatedDate,MonthlyPaymentSetupId,DueDate,MonthId,PreviousDue")] MemberInvoiceList memberInvoiceList)
        {
            if (ModelState.IsValid)
            {
                db.MemberInvoiceList.Add(memberInvoiceList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", memberInvoiceList.MemberId);
            ViewBag.MonthId = new SelectList(db.Month, "MonthId", "MonthName", memberInvoiceList.MonthId);
            return View(memberInvoiceList);
        }

        // GET: MemberInvoiceLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberInvoiceList memberInvoiceList = db.MemberInvoiceList.Find(id);
            if (memberInvoiceList == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", memberInvoiceList.MemberId);
            ViewBag.MonthId = new SelectList(db.Month, "MonthId", "MonthName", memberInvoiceList.MonthId);
            return View(memberInvoiceList);
        }

        // POST: MemberInvoiceLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InvoiceNo,TotalAmount,PaidAmount,DueAmount,MemberId,CreatedDate,MonthlyPaymentSetupId,DueDate,MonthId,PreviousDue")] MemberInvoiceList memberInvoiceList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memberInvoiceList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", memberInvoiceList.MemberId);
            ViewBag.MonthId = new SelectList(db.Month, "MonthId", "MonthName", memberInvoiceList.MonthId);
            return View(memberInvoiceList);
        }

        // GET: MemberInvoiceLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberInvoiceList memberInvoiceList = db.MemberInvoiceList.Find(id);
            if (memberInvoiceList == null)
            {
                return HttpNotFound();
            }
            return View(memberInvoiceList);
        }

        // POST: MemberInvoiceLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MemberInvoiceList memberInvoiceList = db.MemberInvoiceList.Find(id);
            db.MemberInvoiceList.Remove(memberInvoiceList);
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
