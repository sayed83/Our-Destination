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
            var MonthlyPayment = _context.Payment_Master.ToList();
            return View(MonthlyPayment);
        }

        public ActionResult RptPayment()
        {
           IQueryable<Payment_Master> paymentAmount = _context.Payment_Master.Take(20);
            return View(paymentAmount);
        }

        public ActionResult PrintRPT(int id)
        {
            try
            {
                AppData.DBName = _context.Database.Connection.Database;
                //var reportname = _context.Payment_Master.Where(p => p.Payment_MasterId == id).Select(p => p.Member.MemberName).FirstOrDefault();
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