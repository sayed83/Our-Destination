using Microsoft.Reporting.WebForms;
using OurDestination.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OurDestination.Controllers
{
    public class ReportViewerController : Controller
    {
        LocalReport report = new LocalReport();
        private string strMainRP = "";
        private string strMainDSN = "";
        private string strMainQuery = "";
        private DataSet dsReport;
        string strFormat = "";

        //Variabl For Sub Report
        private string subrp = "";
        private string strDSN = "";
        private string strQuery = "";
        private string strRFN = "";


        // GET: ReportViewer
        public ActionResult Index()
        {
            RptConnectionClass clsCon = new RptConnectionClass("OurDestinationDB", true);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string reportpath = "";
            string reportquery = "";
            string reporttype = "PDF";
            string reportformat = "PDF";

            if (Session["ReportPath"] != null)
            {
                reportpath = Session["ReportPath"].ToString();
                Session["ReportPath"] = "";
            }
            if (Session["ReportQuary"] != null)
            {
                reportquery = Session["ReportQuary"].ToString();
            }
            if (Session["ReportType"] != null)
            {
                reporttype = Session["ReportType"].ToString();
                if (reporttype.ToString().ToUpper() == "EXCEL")
                {
                    reportformat = "sls";
                }
                else if (reporttype.ToString().ToUpper() == "WORD")
                {
                    reportformat = "doc";
                }
                else
                {
                    reportformat = "pdf";
                }
            }


            string path = Path.Combine(Server.MapPath(reportpath));
            if (System.IO.File.Exists(path))
            {
                report.ReportPath = path;
            }
            else
            {
                return View("Index");
            }
            report.EnableExternalImages = true;

            clsCon.FillDataSetWithSqlCommand(ref ds, reportquery);
            dt = ds.Tables[0];

            ReportDataSource rd = new ReportDataSource("DataSet1", dt);
            report.DataSources.Add(rd);
            report.SubreportProcessing += new SubreportProcessingEventHandler(prcProdessSubReport);
            string mimeType;
            string encoding;
            string fileNameExtension = "test";
            ReportPageSettings pageSettings = report.GetDefaultPageSettings();
            int width = pageSettings.PaperSize.Width;
            int height = pageSettings.PaperSize.Height;
            int margintop = pageSettings.Margins.Top;
            int marginbottom = pageSettings.Margins.Bottom;
            int marginleft = pageSettings.Margins.Left;
            int marginright = pageSettings.Margins.Right;

            string deviceInfo =
                "<DeviceInfo>" +
                "<OutputFormat>" + "PDF" + "</OutputFormat>" +
                "<PageWidth>" + width + "</PageWidth>" +
                "<PageHeight>" + height + "</PageHeight>" +
                "<MarginTop>" + margintop + "</MarginTop>" +
                "<MarginLeft>" + marginleft + "</MarginLeft>" +
                "<MarginRight>" + marginright + "</MarginRight>" +
                "<MarginBottom>" + marginbottom + "</MarginBottom>" +
                "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytest;

            report.DisplayName = "Report";
            renderedBytest = report.Render(reporttype, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            var sFileName = "MonthlyAmount";
           // var FileName = Session["PrintFileName"].ToString() + "_" + DateTime.Now.ToString("yyyyMMdd");

            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment;filename=" + sFileName + "." + reportformat);
            return File(renderedBytest,mimeType);
        }

        private void prcProdessSubReport(object sender, SubreportProcessingEventArgs e)
        {
            DataTable dtSub = new DataTable();
            string sqlQuery = "";
            string param = "";
            prcGetSubReportDetails(e.ReportPath);
            param = strRFN.Length == 0 ? "" : e.Parameters[strRFN].Values[0].ToString();
            sqlQuery = strQuery + " " + param;

            dtSub = prcGetDataSub(sqlQuery);
            e.DataSources.Add(new ReportDataSource(strDSN, dtSub));
        }

        private DataTable prcGetDataSub(string strQuery)
        {
            DataSet ds = new DataSet();
            RptConnectionClass clsCon = new RptConnectionClass(true);
            try
            {
                clsCon.FillDataSetWithSqlCommand(ref ds, strQuery);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
            finally
            {
                clsCon = null;
            }
            return ds.Tables[0];
        }

        private void prcGetSubReportDetails(string reportPath)
        {
            Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
            postData = Session["rptList"] as Dictionary<int, dynamic>;
            foreach (var item in postData)
            {
                if(item.Value.strRptPathSub.ToUpper() == reportPath.ToUpper())
                {
                    strDSN = item.Value.strDSNSub;
                    strQuery = item.Value.strQuerySub;
                    strRFN = item.Value.strRFNSub;
                }
            }
        }
    }
}