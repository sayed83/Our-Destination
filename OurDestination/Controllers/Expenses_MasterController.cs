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
    public class Expenses_MasterController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Expenses_Master
        public ActionResult Index()
        {
            var expenses_Master = db.Expenses_Master.Include(e => e.Member);
            return View(expenses_Master.ToList());
        }

        // GET: Expenses_Master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expenses_Master expenses_Master = db.Expenses_Master.Find(id);
            if (expenses_Master == null)
            {
                return HttpNotFound();
            }
            return View(expenses_Master);
        }

        // GET: Expenses_Master/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName");
            return View();
        }

        // POST: Expenses_Master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpenceMasterId,ExpensesName,ExpensesAmnount,ExpensesDate,ExpensesDec,userid,comid,EntryDate,AddedBy,MemberId")] Expenses_Master expenses_Master)
        {
            if (ModelState.IsValid)
            {
                db.Expenses_Master.Add(expenses_Master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", expenses_Master.MemberId);
            return View(expenses_Master);
        }

        // GET: Expenses_Master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expenses_Master expenses_Master = db.Expenses_Master.Find(id);
            if (expenses_Master == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", expenses_Master.MemberId);
            return View(expenses_Master);
        }

        // POST: Expenses_Master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpenceMasterId,ExpensesName,ExpensesAmnount,ExpensesDate,ExpensesDec,userid,comid,EntryDate,AddedBy,MemberId")] Expenses_Master expenses_Master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expenses_Master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", expenses_Master.MemberId);
            return View(expenses_Master);
        }

        // GET: Expenses_Master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expenses_Master expenses_Master = db.Expenses_Master.Find(id);
            if (expenses_Master == null)
            {
                return HttpNotFound();
            }
            return View(expenses_Master);
        }

        // POST: Expenses_Master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expenses_Master expenses_Master = db.Expenses_Master.Find(id);
            db.Expenses_Master.Remove(expenses_Master);
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
