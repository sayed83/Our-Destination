using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OurDestination.Models;

namespace OurDestination.Controllers
{
    public class OrdersController1 : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            List<Customer> OrderAndCustomerList = db.Customer.ToList();
            //return View(OrderAndCustomerList);
           // var orders = db.Orders.Include(o => o.Customer);
            return View(OrderAndCustomerList);
        }

        // GET: Orders/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        public ActionResult SaveOrder(string name, String address, Orders[] order)
        {
            string result = "Error! Order Is Not Complete!";
            if (name != null && address != null && order != null)
            {
                var cutomerId = Guid.NewGuid();
                Customer model = new Customer();
                model.CustomerId = cutomerId;
                model.Name = name;
                model.Address = address;
                model.OrderDate = DateTime.Now;
                db.Customer.Add(model);

                foreach (var item in order)
                {
                    var orderId = Guid.NewGuid();
                    Orders O = new Orders();
                    O.OrderId = orderId;
                    O.ProductName = item.ProductName;
                    O.Quantity = item.Quantity;
                    O.Price = item.Price;
                    O.Amount = item.Amount;
                    O.CustomerId = cutomerId;
                    db.Orders.Add(O);
                }
                db.SaveChanges();
                result = "Success! Order Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customer, "CustomerId", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,ProductName,Quantity,Price,Amount,CustomerId")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                orders.OrderId = Guid.NewGuid();
                db.Orders.Add(orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customer, "CustomerId", "Name", orders.CustomerId);
            return View(orders);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customer, "CustomerId", "Name", orders.CustomerId);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,ProductName,Quantity,Price,Amount,CustomerId")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customer, "CustomerId", "Name", orders.CustomerId);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Orders orders = db.Orders.Find(id);
            db.Orders.Remove(orders);
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
