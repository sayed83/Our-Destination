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
    public class CommitteesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Committees
        public ActionResult Index()
        {
            var committee = db.Committee.Include(c => c.Member);
            return View(committee.ToList());
        }

        // GET: Committees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Committee committee = db.Committee.Find(id);
            if (committee == null)
            {
                return HttpNotFound();
            }
            return View(committee);
        }

        // GET: Committees/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName");
            return View();
        }

        // POST: Committees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Position,ElactedDate,userid,comid,EntryDate,AddedBy,MemberId")] Committee committee)
        {
            if (ModelState.IsValid)
            {
                db.Committee.Add(committee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", committee.MemberId);
            return View(committee);
        }

        // GET: Committees/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Title = "Edit";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Committee committee = db.Committee.Find(id);
            if (committee == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", committee.MemberId);
            return View("Create", committee);
        }

        // POST: Committees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Position,ElactedDate,userid,comid,EntryDate,AddedBy,MemberId")] Committee committee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(committee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", committee.MemberId);
            return View(committee);
        }

        // GET: Committees/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.Title = "Delete";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Committee committee = db.Committee.Find(id);
            if (committee == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", committee.MemberId);
            return View("Create", committee);
        }

        // POST: Committees/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {


                Committee committee = db.Committee.Find(id);
                db.Committee.Remove(committee);
                db.SaveChanges();
                return Json(new { Success = 1, id = committee.Id, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {

                TempData["Message"] = "Unable to Delete the Data.";
                TempData["Status"] = "3";
                return Json(new { Success = 0, ex = ex.Message.ToString() });
            }
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
