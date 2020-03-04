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
    public class MemberPaymentTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MemberPaymentTypes
        public ActionResult Index()
        {
            return View(db.MemberPaymentType.ToList());
        }

        // GET: MemberPaymentTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberPaymentType memberPaymentType = db.MemberPaymentType.Find(id);
            if (memberPaymentType == null)
            {
                return HttpNotFound();
            }
            return View(memberPaymentType);
        }

        // GET: MemberPaymentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberPaymentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentId,PaymentType,Active")] MemberPaymentType memberPaymentType)
        {
            if (ModelState.IsValid)
            {
                db.MemberPaymentType.Add(memberPaymentType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(memberPaymentType);
        }

        // GET: MemberPaymentTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberPaymentType memberPaymentType = db.MemberPaymentType.Find(id);
            if (memberPaymentType == null)
            {
                return HttpNotFound();
            }
            return View(memberPaymentType);
        }

        // POST: MemberPaymentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentId,PaymentType,Active")] MemberPaymentType memberPaymentType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memberPaymentType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(memberPaymentType);
        }

        // GET: MemberPaymentTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberPaymentType memberPaymentType = db.MemberPaymentType.Find(id);
            if (memberPaymentType == null)
            {
                return HttpNotFound();
            }
            return View(memberPaymentType);
        }

        // POST: MemberPaymentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MemberPaymentType memberPaymentType = db.MemberPaymentType.Find(id);
            db.MemberPaymentType.Remove(memberPaymentType);
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
