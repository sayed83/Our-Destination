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
    public class PaymentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Payment
        public ActionResult Index()
        {
            var payment_Master = db.Payment_Master.Include(p => p.Department).Include(p => p.Member);
            return View(payment_Master.ToList());
        }

        // GET: Payment/Details/5
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

        // GET: Payment/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName");
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName");
            return View();
        }

        // POST: Payment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentMasterId,MemberId,DepartmentId,AddedBy,UpdatedBy,AddedDate,UpdateDate,userid,comid")] Payment_Master payment_Master)
        {
            if (ModelState.IsValid)
            {
                var membername = db.Member.Where(m => m.MemberId == payment_Master.MemberId).FirstOrDefault();
                if(payment_Master.MemberId == membername.MemberId)
                {
                    return Json("Member Alredy exisit");
                }
                else
                {
                    db.Payment_Master.Add(payment_Master);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }

            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName", payment_Master.DepartmentId);
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", payment_Master.MemberId);
            return View(payment_Master);
        }

        // GET: Payment/Edit/5
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
            return View(payment_Master);
        }

        // POST: Payment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentMasterId,MemberId,DepartmentId,AddedBy,UpdatedBy,AddedDate,UpdateDate,userid,comid")] Payment_Master payment_Master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment_Master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName", payment_Master.DepartmentId);
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", payment_Master.MemberId);
            return View(payment_Master);
        }

        // GET: Payment/Delete/5
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

        // POST: Payment/Delete/5
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
