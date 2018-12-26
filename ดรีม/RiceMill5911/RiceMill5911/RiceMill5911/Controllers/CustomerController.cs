using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RiceMill5911.Models;
using System.Data.Entity;

namespace RiceMill5911.Controllers
{
    public class CustomerController : Controller
    {
        readonly RiceMill5911Entities db = new RiceMill5911Entities();
        // GET: Customer
        public ActionResult Index()
        {
            var data = db.Customer.ToList();
            return View(data);
        }
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer data)
        {
            if (ModelState.IsValid)
            {
                db.Customer.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(string id)
        {
            var data = db.Customer.Find(id);

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Customer data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(data);
        }

        public ActionResult Delete(string id)
        {
            var data = db.Customer.Find(id);
            db.Customer.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(string id)
        {
            var data = db.Customer.Find(id);

            return View(data);
        }

    }
}