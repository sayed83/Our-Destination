using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OurDestination.Models;
using POS_Rezor.Models;

namespace OurDestination.Controllers
{
    public class TransectionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Transections
        public ActionResult Index()
        {
            var transection = db.Transection.Include(t => t.Member);
            return View(transection.ToList());
        }

        // GET: Transections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transection transection = db.Transection.Find(id);
            if (transection == null)
            {
                return HttpNotFound();
            }
            return View(transection);
        }

        // GET: Transections/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName");
            return View();
        }

        // POST: Transections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransectionId,Month,GivenDate,EntryDate,TransectionAmount,userid,comid,MemberId")] Transection transection)
        {
            if (ModelState.IsValid)
            {
                db.Transection.Add(transection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", transection.MemberId);
            return View(transection);
        }

        // GET: Transections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transection transection = db.Transection.Find(id);
            if (transection == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", transection.MemberId);
            return View(transection);
        }

        // POST: Transections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransectionId,Month,GivenDate,EntryDate,TransectionAmount,userid,comid,MemberId")] Transection transection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", transection.MemberId);
            return View(transection);
        }

        // GET: Transections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transection transection = db.Transection.Find(id);
            if (transection == null)
            {
                return HttpNotFound();
            }
            return View(transection);
        }

        // POST: Transections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transection transection = db.Transection.Find(id);
            db.Transection.Remove(transection);
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
