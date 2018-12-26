using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RiceMill5911.Models;
using System.Data.Entity;


namespace RiceMill5911.Controllers
{
    public class BookingFormController : Controller
    {
        readonly RiceMill5911Entities db = new RiceMill5911Entities();
        private readonly ConvertDate td = new ConvertDate();
        // GET: BookingForm
        public ActionResult Index()
        {
            var data = db.BookingForm.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "EmployeeName");
            ViewBag.CustomerUsre = new SelectList(db.Customer, "CustomerUsre", "CustomerName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(BookingForm data)
        {
            if (ModelState.IsValid)
            {
                //แปลงวันที่ คศ-->พศ
                data.BookingDate = td.ThaiDate(data.MyDate);
                data.BookingWant = td.ThaiDate(data.MyDate1);
                data.BookingSubmit = td.ThaiDate(data.MyDate2);

                db.BookingForm.Add(data);
                db.SaveChanges();
                return RedirectToAction("Create", "BookingDescription");
            }
            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "EmployeeName");
            ViewBag.CustomerUsre = new SelectList(db.Customer, "CustomerUsre", "CustomerName");
            return View();
        }

        public ActionResult Edit(int id)
        {
            var data = db.BookingForm.Find(id);
            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "EmployeeName");
            ViewBag.CustomerUsre = new SelectList(db.Customer, "CustomerUsre", "CustomerName");
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(BookingForm data)
        {
            if (ModelState.IsValid)
            {

                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "EmployeeName");
            ViewBag.CustomerUsre = new SelectList(db.Customer, "CustomerUsre", "CustomerName");
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = db.BookingForm.Find(id);
            db.BookingForm.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var data = db.BookingForm.Find(id);

            return View(data);
        }
    }
}