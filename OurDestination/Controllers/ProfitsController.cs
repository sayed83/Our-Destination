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
    public class ProfitsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Profits
        public ActionResult Index()
        {
            var profit = db.Profit.Include(p => p.Invest);
            return View(profit.ToList());
        }

        // GET: Profits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profit profit = db.Profit.Find(id);
            if (profit == null)
            {
                return HttpNotFound();
            }
            return View(profit);
        }

        // GET: Profits/Create
        public ActionResult Create()
        {
            ViewBag.InvestId = new SelectList(db.Invest, "InvestId", "InvestPurpose");
            return View();
        }

        // POST: Profits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfitId,ProfitDec,ProfitAmount,GivenDate,userid,comid,EntryDate,AddedBy,InvestId")] Profit profit)
        {
            if (ModelState.IsValid)
            {
                db.Profit.Add(profit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InvestId = new SelectList(db.Invest, "InvestId", "InvestPurpose", profit.InvestId);
            return View(profit);
        }

        // GET: Profits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profit profit = db.Profit.Find(id);
            if (profit == null)
            {
                return HttpNotFound();
            }
            ViewBag.InvestId = new SelectList(db.Invest, "InvestId", "InvestPurpose", profit.InvestId);
            return View(profit);
        }

        // POST: Profits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfitId,ProfitDec,ProfitAmount,GivenDate,userid,comid,EntryDate,AddedBy,InvestId")] Profit profit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InvestId = new SelectList(db.Invest, "InvestId", "InvestPurpose", profit.InvestId);
            return View(profit);
        }

        // GET: Profits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profit profit = db.Profit.Find(id);
            if (profit == null)
            {
                return HttpNotFound();
            }
            return View(profit);
        }

        // POST: Profits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profit profit = db.Profit.Find(id);
            db.Profit.Remove(profit);
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
        protected override void Dispose1(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
