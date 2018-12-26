using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RiceMill5911.Models;
using System.Data.Entity;

namespace RiceMill5911.Controllers
{
    public class BuyFormController : Controller
    {
        readonly RiceMill5911Entities db = new RiceMill5911Entities();
        private readonly ConvertDate td = new ConvertDate();
        // GET: BuyForm
        public ActionResult Index()
        {
            var data = db.BuyForm.ToList();
            return View(data);
        }
        public ActionResult buyRicdetai(int BuyID=0,int RicID=0)
        {
            Session["Price"] = 0;
            Session["NameRice"] = "";
            if (BuyID != 0)
            {
                Session["IDR"] = BuyID;
            }
            if (RicID != 0)
            {
               
                var PriceRIC = db.Rice.Where(w => w.RiceID == RicID).FirstOrDefault();
                Session["Price"] = PriceRIC.PurchasePrice;
                Session["IDI"] = PriceRIC.RiceID;
                Session["NameRice"] = PriceRIC.RiceName;

            }


            ViewBag.BuyRice = new SelectList(db.Rice, "RiceID", "RiceName");
            ViewBag.ConditionID = new SelectList(db.Condition, "ConditionID", "ConditionName");
            ViewBag.StatusRiceID = new SelectList(db.StatusRice, "StatusRiceID", "StatusRiceName");
          
            return View();
        }

        [HttpPost]
        public ActionResult AddList(BuyDescription data)
        {
            var ID = Convert.ToInt32(Session["IDI"]);
            var chk = db.Rice.Where(a => a.RiceID == ID).FirstOrDefault();
            data.BuyTotal = data.BuyAmount * chk.PurchasePrice;
            data.BuyRice = Convert.ToInt32(Session["IDI"]) ;
            db.BuyDescription.Add(data);
            db.SaveChanges();
            Numberrice(data.BuyRice,data.BuyAmount);
            return RedirectToAction(nameof(Index));
        }

        public void Numberrice(int? Id=0,double? on=0)
        {
            var data = db.Rice.Where(x => x.RiceID == Id).FirstOrDefault();
            data.WareHouse = data.WareHouse + on;
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();
        }
        public ActionResult Create()
        {
            ViewBag.DealerID = new SelectList(db.Dealer, "DealerID", "DealerName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(BuyForm data)
        {

           if (ModelState.IsValid)
            {
                db.BuyForm.Add(data);
                db.SaveChanges();
                return RedirectToAction("Create","BuyDescription");
            }

            ViewBag.DealerID = new SelectList(db.Dealer, "DealerID", "DealerName");
            return View();

        }

        public ActionResult Edit(int id)
        {
            var data = db.BuyForm.Find(id);

            ViewBag.DealerID = new SelectList(db.Dealer, "DealerID", "DealerName");
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

            ViewBag.DealerID = new SelectList(db.Dealer, "DealerID", "DealerName");
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = db.BuyForm.Find(id);
            db.BuyForm.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var data = db.BuyDescription.Where(a => a.BuyID == id).ToList();

            return View(data);
        }










    }
}