using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RiceMill5911.Models;

namespace RiceMill5911.Controllers
{
    public class RicesController : Controller
    {
        readonly RiceMill5911Entities db = new RiceMill5911Entities();
        // GET: Rices
        public ActionResult Index()
        {
            var data = db.Rice.ToList();
            return View(data);
        }

        public ActionResult Create()
        {

            ViewBag.TypeRiceID = new SelectList(db.TypeRice, "TypeRiceID", "TypeRiceName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Rice data)
        {
            if (ModelState.IsValid)
            {
              
                //แปลงภาพให้เป็นไบนารีก่อน
                if (data.MyPic != null)
                {
                    byte[] Temp = new byte[data.MyPic.ContentLength];
                    data.MyPic.InputStream.Read(Temp, 0, data.MyPic.ContentLength);
                    data.RicePicture = Temp;
                }

               
                   //ตรวจสอบชื่อ ถ้าซ้ำบันทึกไม่ได้
                    db.Rice.Add(data);
                    db.SaveChanges();
                    return RedirectToAction("Index");
               

            }

            ViewBag.TypeRiceID = new SelectList(db.TypeRice, "TypeRiceID", "TypeRiceName");
            return View();
        }


        public ActionResult Edit(int id)
        {
            var data = db.Rice.Find(id);


            ViewBag.TypeRiceID = new SelectList(db.TypeRice, "TypeRiceID", "TypeRiceName");
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Rice data)
        {
           
            if (ModelState.IsValid)
            {
             

                //แปลงภาพให้เป็นไบนารีก่อน
                if (data.MyPic != null)
                {
                    byte[] Temp = new byte[data.MyPic.ContentLength];
                    data.MyPic.InputStream.Read(Temp, 0, data.MyPic.ContentLength);
                    data.RicePicture = Temp;
                }

                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypeRiceID = new SelectList(db.TypeRice, "TypeRiceID", "TypeRiceName");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var data = db.Rice.Find(id);
            db.Rice.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var data = db.Rice.Find(id);

            return View(data);
        }
        //public ActionResult Details(int RiceID)
        //{
        //    var data = db.Rice.Where(a => a.RiceID == RiceID).FirstOrDefault();

        //    return View(data);
        //}

    }
}