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
    public class MembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Members
        public ActionResult Index()
        {
            var member = db.Member.Include(m => m.BloodGroup);
            return View(member.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "BloodGroupId", "BloodGroupName");
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberId,MemberName,JoiningDate,FatherName,MotherName,SpouseName,Nationality,DOB,Email,PhotoPath,Image,PhoneNo,MaritalStatus,Religion,Gender,EducationalQualification,NIDNo,PassportNo,TinNo,PresentAddress,PermanentAddress,NomineeName,RelationWithNominee,NomineeNIDNo,NomineePhoneNo,userid,comid,IsActive,EntryDate,BloodGroupId")] Member member)
        {
            if (ModelState.IsValid)
            {
                if( member.MemberId > 0)
                {
                    db.Entry(member).State = EntityState.Modified;
                }
                else
                {
                    db.Member.Add(member);
                }

                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "BloodGroupId", "BloodGroupName", member.BloodGroupId);
            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Title = "Edit";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "BloodGroupId", "BloodGroupName", member.BloodGroupId);
            return View("Create",member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberId,MemberName,JoiningDate,FatherName,MotherName,SpouseName,Nationality,DOB,Email,PhotoPath,Image,PhoneNo,MaritalStatus,Religion,Gender,EducationalQualification,NIDNo,PassportNo,TinNo,PresentAddress,PermanentAddress,NomineeName,RelationWithNominee,NomineeNIDNo,NomineePhoneNo,userid,comid,IsActive,EntryDate,BloodGroupId")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "BloodGroupId", "BloodGroupName", member.BloodGroupId);
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.Title = "Delete";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Member.Find(id);
            db.Member.Remove(member);
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
