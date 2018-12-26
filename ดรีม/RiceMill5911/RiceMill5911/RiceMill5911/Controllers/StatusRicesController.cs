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
    public class StatusRicesController : Controller
    {
        private RiceMill5911Entities db = new RiceMill5911Entities();

        // GET: StatusRices
        public ActionResult Index()
        {
            return View(db.StatusRice.ToList());
        }

        // GET: StatusRices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusRice statusRice = db.StatusRice.Find(id);
            if (statusRice == null)
            {
                return HttpNotFound();
            }
            return View(statusRice);
        }

        // GET: StatusRices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusRices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatusRiceID,StatusRiceName")] StatusRice statusRice)
        {
            if (ModelState.IsValid)
            {
                db.StatusRice.Add(statusRice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusRice);
        }

        // GET: StatusRices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusRice statusRice = db.StatusRice.Find(id);
            if (statusRice == null)
            {
                return HttpNotFound();
            }
            return View(statusRice);
        }

        // POST: StatusRices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatusRiceID,StatusRiceName")] StatusRice statusRice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusRice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusRice);
        }

        // GET: StatusRices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusRice statusRice = db.StatusRice.Find(id);
            if (statusRice == null)
            {
                return HttpNotFound();
            }
            return View(statusRice);
        }

        // POST: StatusRices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusRice statusRice = db.StatusRice.Find(id);
            db.StatusRice.Remove(statusRice);
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
