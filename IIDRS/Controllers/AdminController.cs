using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IIDRS.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        
        public ActionResult AdminActivities()
        {
            if (Session["Admin"] != null)
            {
                return View();
            }
            return RedirectToAction("Login2", "Home");
        }
    }
}