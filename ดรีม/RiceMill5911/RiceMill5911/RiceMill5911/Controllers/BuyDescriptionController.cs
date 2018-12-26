using RiceMill5911.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;



namespace RiceMill5911.Controllers
{
    public class BuyDescriptionController : Controller
    {
        readonly RiceMill5911Entities db = new RiceMill5911Entities();
        // GET: BuyDescription
        public ActionResult Index()
        {
            var data = db.BuyDescription.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            ViewBag.BuyRice = new SelectList(db.Rice, "RiceID", "RiceName");
            ViewBag.ConditionID = new SelectList(db.Condition, "ConditionID", "ConditionName");
            ViewBag.StatusRiceID = new SelectList(db.StatusRice, "StatusRiceID", "StatusRiceName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(BuyDescription data)
        {

            if (ModelState.IsValid)
            {
                db.BuyDescription.Add(data);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.BuyRice = new SelectList(db.Rice, "RiceID", "RiceName",data.BuyRice);
            ViewBag.ConditionID = new SelectList(db.Condition, "ConditionID", "ConditionName",data.ConditionID);
            ViewBag.StatusRiceID = new SelectList(db.StatusRice, "StatusRiceID", "StatusRiceName", data.StatusRiceID);


            return View(data);
        }



        public ActionResult Edit(int id)
        {
            var data = db.BuyDescription.Find(id);

            ViewBag.BuyRice = new SelectList(db.Rice, "RiceID", "RiceName");
            ViewBag.ConditionID = new SelectList(db.Condition, "ConditionID", "ConditionName");
            ViewBag.StatusRiceID = new SelectList(db.StatusRice, "StatusRiceID", "StatusRiceName");
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(BuyDescription data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BuyRice = new SelectList(db.Rice, "RiceID", "RiceName", data.BuyRice);
            ViewBag.ConditionID = new SelectList(db.Condition, "ConditionID", "ConditionName", data.ConditionID);
            ViewBag.StatusRiceID = new SelectList(db.StatusRice, "StatusRiceID", "StatusRiceName", data.StatusRiceID);
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = db.BuyDescription.Find(id);
            db.BuyDescription.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var data = db.BuyDescription.Find(id);

            return View(data);
        }



    }
    
}