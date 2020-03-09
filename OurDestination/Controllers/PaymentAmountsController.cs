using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OurDestination.Data;
using OurDestination.Models;

namespace OurDestination.Controllers
{
    public class PaymentAmountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PaymentAmounts
        public ActionResult Index(string FromDate, string ToDate)
        {
            DateTime FDate, TDate;
            if(FromDate == null || FromDate == "")
            {
                FDate = Convert.ToDateTime(DateTime.Now.Date);
            }
            else
            {
                FDate = Convert.ToDateTime(FromDate);
            }

            if(ToDate == null || ToDate == "")
            {
                TDate = Convert.ToDateTime(DateTime.Now.Date);
            }
            else
            {
                TDate = Convert.ToDateTime(ToDate);
            }

            var paymentAmount = db.PaymentAmount.Include(p => p.Department).Include(p => p.Member).Include(p=>p.MemberPaymentType);
            return View(paymentAmount.ToList());
        }

        public ActionResult PrintRPT(int? id, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                AppData.DBName = db.Database.Connection.Database;
                var reportname = db.PaymentAmount.Where(p => p.PaymentAmountId == id).Select(p => p.Member.MemberName).FirstOrDefault();
                Session["ReportPath"] = "~/Reports/MonthlyPayment.rdlc";
                Session["ReportQuary"] = "EXEC " + AppData.DBName.ToString() + ".dbo.[rptMonthlyPayment]";
                string DatabaseSourceName = "DetaSet1";
                ClsReport.ReportPathMain = Session["ReportPath"].ToString();
                ClsReport.QuaryMain = Session["ReportQuary"].ToString();
                ClsReport.DataSetMain = DatabaseSourceName;
                return RedirectToAction("Index", "ReportViewer");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult RptPaymentAmount(string ReportType, string Action, DateTime FromDate, DateTime ToDate)
        {
            Session["ReportType"] = ReportType;
            string RedirectUrl = "";
            if(Action == "PrintRPT")
            {
                RedirectUrl = new UrlHelper(Request.RequestContext).Action(Action, "PaymentAmounts", new { FromDate = FromDate, ToDate = ToDate });
            }
            else
            {
                RedirectUrl = new UrlHelper(Request.RequestContext).Action(Action, "PaymentAmounts", new { FromDate = FromDate, ToDate = ToDate });
            }
            return Json(new {Url = RedirectUrl });
        }

        // GET: PaymentAmounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentAmount paymentAmount = db.PaymentAmount.Find(id);
            if (paymentAmount == null)
            {
                return HttpNotFound();
            }
            return View(paymentAmount);
        }

        // GET: PaymentAmounts/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.MonthId = new SelectList(db.Month, "MonthId", "MonthName");
            ViewBag.PaymentTypeId = new SelectList(db.MemberPaymentType, "PaymentTypeId", "PaymentType");
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName");
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName");
            return View();
        }

        // POST: PaymentAmounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentAmountId,PaymentTypeId,MemberId,DepartmentId,Amount,Active,userid,comid,MonthId")] PaymentAmount paymentAmount)
        {
            if (ModelState.IsValid)
            {
                db.PaymentAmount.Add(paymentAmount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MonthId = new SelectList(db.Month, "MonthId", "MonthName", paymentAmount.MonthId);
            ViewBag.PaymentTypeId = new SelectList(db.MemberPaymentType, "PaymentTypeId", "PaymentType", paymentAmount.PaymentTypeId);
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName", paymentAmount.DepartmentId);
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", paymentAmount.MemberId);
            return View(paymentAmount);
        }

        // GET: PaymentAmounts/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Title = "Edit";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentAmount paymentAmount = db.PaymentAmount.Find(id);
            if (paymentAmount == null)
            {
                return HttpNotFound();
            }
            ViewBag.MonthId = new SelectList(db.Month, "MonthId", "MonthName", paymentAmount.MonthId);
            ViewBag.PaymentTypeId = new SelectList(db.MemberPaymentType, "PaymentTypeId", "PaymentType", paymentAmount.PaymentTypeId);
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName", paymentAmount.DepartmentId);
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", paymentAmount.MemberId);
            return View("Create",paymentAmount);
        }

        // POST: PaymentAmounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentAmountId,PaymentTypeId,MemberId,DepartmentId,Amount,Active,userid,comid,MonthId")] PaymentAmount paymentAmount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentAmount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MonthId = new SelectList(db.Month, "MonthId", "MonthName", paymentAmount.MonthId);
            ViewBag.PaymentTypeId = new SelectList(db.MemberPaymentType, "PaymentTypeId", "PaymentType", paymentAmount.PaymentTypeId);
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName", paymentAmount.DepartmentId);
            ViewBag.MemberId = new SelectList(db.Member, "MemberId", "MemberName", paymentAmount.MemberId);
            return View(paymentAmount);
        }

        // GET: PaymentAmounts/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.Title = "Delete";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentAmount paymentAmount = db.PaymentAmount.Find(id);
            if (paymentAmount == null)
            {
                return HttpNotFound();
            }
            return View("Create",paymentAmount);
        }

        // POST: PaymentAmounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymentAmount paymentAmount = db.PaymentAmount.Find(id);
            db.PaymentAmount.Remove(paymentAmount);
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
