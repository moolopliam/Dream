using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RiceMill5911.Models;
using System.Data.Entity;

namespace RiceMill5911.Controllers
{
    public class BookingDescriptionController : Controller
    {
        readonly RiceMill5911Entities db = new RiceMill5911Entities();
        // GET: BookingDescription
        public ActionResult Index()
        {
            var data = db.BookingDescription.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            ViewBag.BookRice = new SelectList(db.Rice, "RiceID", "RiceName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(BookingDescription data)
        {
            if (ModelState.IsValid)
            {
                db.BookingDescription.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.BookRice = new SelectList(db.Rice, "RiceID", "RiceName", data.BookRice);

            return View();
        }

        public ActionResult Edit(int id)
        {
            var data = db.BookingDescription.Find(id);
            ViewBag.BookRice = new SelectList(db.Rice, "RiceID", "RiceName");
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(BookingDescription data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookRice = new SelectList(db.Rice, "RiceID", "RiceName", data.BookRice);
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = db.BookingDescription.Find(id);
            db.BookingDescription.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var data = db.BookingDescription.Find(id);

            return View(data);
        }

    }
}