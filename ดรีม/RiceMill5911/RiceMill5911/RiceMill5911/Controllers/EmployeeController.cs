using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RiceMill5911.Models;
using System.Data.Entity;

namespace RiceMill5911.Controllers
{
    public class EmployeeController : Controller
    {
        readonly RiceMill5911Entities db = new RiceMill5911Entities();
        // GET: Employee
        public ActionResult Index()
        {
            var data = db.Employee.ToList();
            return View(data);
        }
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee data)
        {
            if (ModelState.IsValid)
            {
                //var data1 = db.Employee.ToList();
                //data.EmployeeID = data1.Count()+1;
                db.Employee.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(data);

        }

        public ActionResult Edit(string id)
        {
            var data = db.Employee.Find(id);

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Employee data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(data);
        }

        public ActionResult Details(string ID)
        {
            var data = db.Employee.Find(ID);
            return View(data);
        }
    }
}