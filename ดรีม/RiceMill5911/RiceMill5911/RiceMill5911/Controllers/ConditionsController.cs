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
    public class ConditionsController : Controller
    {
        private RiceMill5911Entities db = new RiceMill5911Entities();

        // GET: Conditions
        public ActionResult Index()
        {
            return View(db.Condition.ToList());
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Condition data)
        {
            if (ModelState.IsValid)
            {
                db.Condition.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var data = db.Condition.Find(id);

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Condition data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = db.Condition.Find(id);
            db.Condition.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var data = db.Condition.Find(id);

            return View(data);
        }
    }
}
