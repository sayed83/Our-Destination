using OurDestination.Data;
using OurDestination.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OurDestination.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            this._context = context;
        }
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RptPayment()
        {
           IQueryable<PaymentAmount> paymentAmount = _context.PaymentAmount.Take(20);
            return View(paymentAmount);
        }

        public ActionResult PrintRPT(int id)
        {
            try
            {
                AppData.DBName = _context.Database.Connection.Database;
                var reportname = _context.PaymentAmount.Where(p => p.PaymentAmountId == id).Select(p => p.Member.MemberName).FirstOrDefault();
                Session["ReportPath"] = "~/Report/MonthlyPayment.rdlc";
                Session["ReportQuary"] = "EXEC" + AppData.DBName.ToString() + ".dbo.[rptGlobalSearch]'" + id +"'";
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
    }
}