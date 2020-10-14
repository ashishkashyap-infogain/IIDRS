using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IIDRS.Controllers
{
    public class HomeController : Controller
    {
        private DataModel db = new DataModel();

        [HttpGet]
        public ActionResult Login2()
        {
            //var list = db.T_Logins.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Login2([Bind(Include = "LOGIN,PASSWORD")] M_USER model)
        {
            //model.USER_FLG = false;
            var res = db.M_USER.Where(x => x.LOGIN == model.LOGIN).FirstOrDefault();
            if (res != null)
            {
                var pass = res.PASSWORD == model.PASSWORD;
                if (pass == true)
                {
                    Session["LogedUser"] = res.LOGIN;
                    if (res.LOGIN_DOMAIN == "Customer")
                    {
                        Session["CustId"] = res.USER_ID;
                        Session["Admin"] = null;
                        //int value = Convert.ToInt32(res.CustomerId);
                        return RedirectToAction("Index", "Survey");
                    }
                    else if (res.LOGIN_DOMAIN == "Admin")
                    {
                        Session["Admin"] = res.USER_ID;
                        Session["CustId"] = null;
                        return RedirectToAction("AdminActivities", "Admin");
                    }
                    else if (res.LOGIN_DOMAIN == "Sales")
                    {
                        return RedirectToAction("Index", "Sales");
                    }
                }
            }
            ViewBag.Error = "Username and Password do not Match";
            return View("Login2");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["Admin"] = null;
            Session["CustId"] = null;

            return RedirectToAction("Login2");

        }

    }
}