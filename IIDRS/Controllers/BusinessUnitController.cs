using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IIDRS.Controllers
{
    public class BusinessUnitController : Controller
    {
        private DataModel db = new DataModel();
        // GET: BusinessUnit
        public ActionResult GetAllBU()
        {
            if (Session["Admin"] != null)
            {
                var m_BUs = db.M_BU.Where(x => x.BU_FLG == "1").OrderByDescending(x => x.CREATED_DT);
                return View("GetAllBU", m_BUs.ToList());
            }
            return RedirectToAction("Login2", "Home");
        }
    }
}