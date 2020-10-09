using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IIDRS.Controllers
{
    public class ContactController : Controller
    {
        private DataModel db = new DataModel();
        // GET: Contact
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                ViewBag.count = 4;
                var res = db.M_CONTACT.ToList();
                return View(res);
            }
            return RedirectToAction("Login2", "Home");
        }
    }
}