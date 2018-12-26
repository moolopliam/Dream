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
    public class TypeRicesController : Controller
    {
        private RiceMill5911Entities db = new RiceMill5911Entities();

        // GET: TypeRices
        public ActionResult Index()
        {
            return View(db.TypeRice.ToList());
        }

        // GET: TypeRices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeRice typeRice = db.TypeRice.Find(id);
            if (typeRice == null)
            {
                return HttpNotFound();
            }
            return View(typeRice);
        }

        // GET: TypeRices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeRices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeRiceID,TypeRiceName")] TypeRice typeRice)
        {
            if (ModelState.IsValid)
            {
                db.TypeRice.Add(typeRice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeRice);
        }

        // GET: TypeRices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeRice typeRice = db.TypeRice.Find(id);
            if (typeRice == null)
            {
                return HttpNotFound();
            }
            return View(typeRice);
        }

        // POST: TypeRices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeRiceID,TypeRiceName")] TypeRice typeRice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeRice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeRice);
        }

        // GET: TypeRices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeRice typeRice = db.TypeRice.Find(id);
            if (typeRice == null)
            {
                return HttpNotFound();
            }
            return View(typeRice);
        }

        // POST: TypeRices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeRice typeRice = db.TypeRice.Find(id);
            db.TypeRice.Remove(typeRice);
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
