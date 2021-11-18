using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OurDestination.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShoppingCard()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string RandomDigits(int Length, string data)
        {
            DateTime date = DateTime.Now;
            string UniqueId = string.Format("{1:00}{2:00}{3:00}{0:0000}", date.Month, date.Day, date.Millisecond, date.Year);
            UniqueId = new string(UniqueId.Take(Length).ToArray());
            return date + "-" + UniqueId;
        }

        public string RandomDigits1(int Length, string data)
        {
            DateTime date = DateTime.Now;
            string UniqueId = string.Format("{1:00}{2:00}{3:00}{0:0000}", date.Month, date.Day, date.Millisecond, date.Year);
            UniqueId = new string(UniqueId.Take(Length).ToArray());
            return date + "-" + UniqueId;
        }


    }
}