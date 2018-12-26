using RiceMill5911.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RiceMill5911.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(UserLogin objUse)
        {
            if (ModelState.IsValid)
            {
                using (RiceMill5911Entities db = new RiceMill5911Entities())
                {

                    var obj = db.UserLogin.Where(a => a.UserName.Equals(objUse.UserName) && a.Password.Equals(objUse.Password)).FirstOrDefault();

                    if (obj != null)
                    {
                        //Session["AdminID"] = obj.AdminID.ToString();
                        //Session["Adname"] = obj.AdminID.ToString();
                        return RedirectToAction("Index", "ShowLogin");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid login credentials.");
                    }
                }
            }
            return View(objUse);
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }

    }
}
