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
    public class InvestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Invests
        public ActionResult Index()
        {
            var invest = db.Invest.Include(i => i.Member);
            return View(invest.ToList());
        }

        // GET: Invests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invest invest = db.Invest.Find(id);
            if (invest == null)
            {
                return HttpNotFound();
            }
            return View(invest);
        }

        // GET: Invests/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName");
            return View();
        }

        // POST: Invests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvestId,InvestPurpose,InvestAmount,InvestDate,ExpireDate,userid,comid,EntryDate,AddedBy,MemberId")] Invest invest)
        {
            if (ModelState.IsValid)
            {
                db.Invest.Add(invest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", invest.MemberId);
            return View(invest);
        }

        // GET: Invests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invest invest = db.Invest.Find(id);
            if (invest == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", invest.MemberId);
            return View(invest);
        }

        // POST: Invests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvestId,InvestPurpose,InvestAmount,InvestDate,ExpireDate,userid,comid,EntryDate,AddedBy,MemberId")] Invest invest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", invest.MemberId);
            return View(invest);
        }

        // GET: Invests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invest invest = db.Invest.Find(id);
            if (invest == null)
            {
                return HttpNotFound();
            }
            return View(invest);
        }

        // POST: Invests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invest invest = db.Invest.Find(id);
            db.Invest.Remove(invest);
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
