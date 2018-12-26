using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RiceMill5911.Models;

namespace RiceMill5911.Controllers
{
    public class StatusBookingsController : Controller
    {
        private RiceMill5911Entities db = new RiceMill5911Entities();

        // GET: StatusBookings
        public ActionResult Index()
        {
            return View(db.StatusBooking.ToList());
        }

        // GET: StatusBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusBooking statusBooking = db.StatusBooking.Find(id);
            if (statusBooking == null)
            {
                return HttpNotFound();
            }
            return View(statusBooking);
        }

        // GET: StatusBookings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusBookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatusBookingID,StatusBookingName")] StatusBooking statusBooking)
        {
            if (ModelState.IsValid)
            {
                db.StatusBooking.Add(statusBooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusBooking);
        }

        // GET: StatusBookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusBooking statusBooking = db.StatusBooking.Find(id);
            if (statusBooking == null)
            {
                return HttpNotFound();
            }
            return View(statusBooking);
        }

        // POST: StatusBookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatusBookingID,StatusBookingName")] StatusBooking statusBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusBooking);
        }

        // GET: StatusBookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusBooking statusBooking = db.StatusBooking.Find(id);
            if (statusBooking == null)
            {
                return HttpNotFound();
            }
            return View(statusBooking);
        }

        // POST: StatusBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusBooking statusBooking = db.StatusBooking.Find(id);
            db.StatusBooking.Remove(statusBooking);
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
