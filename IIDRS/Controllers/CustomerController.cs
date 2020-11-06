using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace IIDRS.Controllers
{
    public class CustomerController : Controller
    {
        private DataModel db = new DataModel();


        //[HttpPost]

        //public ActionResult Create(M_ORG_EXT m_org_ext)
        //{
        //    if (Session["Admin"] != null)
        //    {

        //        var sess = Session["Admin"].ToString();

        //        M_PARTY m_PARTY = new M_PARTY();

        //        //for alphanumeric PARTY_TYPE_CD
        //        var checks = db.M_PARTY.Where(x => x.PARTY_TYPE_CD.Contains("ORGEXT")).ToList();
        //        m_PARTY.PARTY_TYPE_CD = checks.Max(x => x.PARTY_TYPE_CD);

        //        if (m_PARTY.PARTY_TYPE_CD == "0" || m_PARTY.PARTY_TYPE_CD == null)
        //        {
        //            m_PARTY.PARTY_TYPE_CD = "1-1ORGEXT";
        //        }
        //        else
        //        {
        //            StringBuilder sb1 = new StringBuilder();
        //            var res1 = Regex.Split(m_PARTY.PARTY_TYPE_CD, @"ORGEXT");
        //            var chng1 = res1[0].ToString().Split('-');
        //            var inc1 = ((Convert.ToInt32(chng1[1])) + 1).ToString();

        //            sb1.Append("2-" + inc1 + "ORGEXT");
        //            m_PARTY.PARTY_TYPE_CD = sb1.ToString();

        //        }
        //        //for alphanumeric PARTY_UID

        //        var checks1 = db.M_PARTY.Where(x => x.PARTY_UID.Contains("G")).ToList();
        //        m_PARTY.PARTY_UID = checks1.Max(x => x.PARTY_UID);
        //        if (m_PARTY.PARTY_UID == "0" || m_PARTY.PARTY_UID == null)
        //        {
        //            m_PARTY.PARTY_UID = "1-1G";
        //        }
        //        else
        //        {
        //            StringBuilder sb2 = new StringBuilder();
        //            var res2 = Regex.Split(m_PARTY.PARTY_UID, @"G");
        //            var chng2 = res2[0].ToString().Split('-');
        //            var inc2 = (Convert.ToInt32(chng2[1]) + 1).ToString();
        //            sb2.Append("2-" + inc2 + "G");
        //            m_PARTY.PARTY_UID = sb2.ToString();
        //        }
        //        m_PARTY.TRANS_FLG = "1";
        //        m_PARTY.CREATED_DT = System.DateTime.Now;
        //        m_PARTY.LAST_UPD_DT = System.DateTime.Now;
        //        m_PARTY.ACTIVE_FLG = "1";


        //        m_org_ext.ROW_ID = db.M_ORG_EXT.Max(x => x.ROW_ID);

        //        //for alphanumeric user id   
        //        var res = Regex.Split(m_org_ext.ROW_ID, @"\D+");

        //        if (m_org_ext.ROW_ID == "0" || m_org_ext.ROW_ID == null)
        //        {
        //            m_org_ext.ROW_ID = "1-1GORGEXT";
        //        }
        //        else
        //        {


        //            StringBuilder sb = new StringBuilder("2-");
        //            var chng = res[1].ToString();
        //            var inc = (Convert.ToInt32(chng) + 1).ToString();
        //            sb.Append(inc + "GORGEXT");
        //            m_org_ext.ROW_ID = sb.ToString();
        //        }
        //        //for bu id

        //        //var buId = Regex.Split(m_org_ext.BU_ID, @"\D+");

        //        //if (m_org_ext.BU_ID == "0" || m_org_ext.BU_ID == null)
        //        //{
        //        //    m_org_ext.BU_ID = "1-1CBUID";
        //        //}
        //        //else
        //        //{


        //        //    StringBuilder sb = new StringBuilder("2-");
        //        //    var chng = buId[1].ToString();
        //        //    var inc = (Convert.ToInt32(chng) + 1).ToString();
        //        //    sb.Append(inc + "CBUID");
        //        //    m_org_ext.BU_ID = sb.ToString();
        //        //}



        //        m_org_ext.CREATED_DT = System.DateTime.Now;
        //        m_org_ext.LAST_UPD_DT = System.DateTime.Now;
        //        //m_org_ext.PW_LAST_UPD = System.DateTime.Now.ToString();
        //        m_org_ext.CREATED_BY = sess;
        //        m_org_ext.LAST_UPD_BY = sess;
        //        m_org_ext.ACTIVE_FLG = "1";
        //        m_org_ext.BU_ID ="2-2BU";
        //        m_org_ext.PAR_ROW_ID = m_PARTY.PARTY_TYPE_CD;
        //        db.M_PARTY.Add(m_PARTY);
        //        db.M_ORG_EXT.Add(m_org_ext);
        //        db.SaveChanges();
        //        return RedirectToAction("OrgEdit");
        //    }
        //    return RedirectToAction("Login2", "Home");
        //}

        //[HttpPost, ActionName("Delete")]

        //public ActionResult DeleteConfirmed(M_ORG_EXT id)
        //{
        //    if (Session["Admin"] != null)
        //    {

        //        if (id.ROW_ID != null)
        //        {
        //            id.ROW_ID = id.ROW_ID.Trim();
        //            M_ORG_EXT m_ORG = db.M_ORG_EXT.Find(id.ROW_ID);
        //            m_ORG.ACTIVE_FLG = "0";
        //            db.SaveChanges();
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Login2", "Home");
        //}

        ////Edit customer
        //[HttpPost]
        //public ActionResult Edit(M_ORG_EXT m_org_ext)
        //{

        //    if (Session["Admin"] != null)
        //    {
        //        var sess = Session["Admin"].ToString();
        //        if (m_org_ext.ROW_ID != null)
        //        {
        //            m_org_ext.ROW_ID = m_org_ext.ROW_ID.Trim();
        //            var rowId = db.M_ORG_EXT.Where(x => x.ROW_ID == m_org_ext.ROW_ID).FirstOrDefault();
        //            if (rowId != null)
        //            {
        //                rowId.NAME = m_org_ext.NAME.Trim();
        //                rowId.LOC = m_org_ext.LOC.Trim();
        //               // rowId.RATING = m_org_ext.RATING.Trim();


        //                rowId.NAME = m_org_ext.NAME;
        //                rowId.LOC = m_org_ext.LOC;
        //                rowId.RATING = m_org_ext.RATING;


        //                rowId.LAST_UPD_DT = System.DateTime.Now;
        //                rowId.LAST_UPD_BY = sess;
        //                db.SaveChanges();
        //            }
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Login2", "Home");

        //}

        //public ActionResult GetAllBU(string getBUListByCondition = "1")
        //{
        //    List<BUViewModel> list = new List<BUViewModel>();
        //    GetAction();
        //    if (Session["Admin"] != null)
        //    {

        //        var BU_User_Details = from bu in db.M_BU
        //                              join contact in db.M_CONTACT on bu.BU_ID equals contact.BU_ID
        //                              orderby bu.CREATED_DT descending
        //                              select new { contact.FST_NAME, contact.LAST_NAME, contact.EMAIL_ADDR, contact.PHONE_NO, bu.BU_NAME, bu.BU_ID, bu.BU_TYPE, bu.DU_NAME, bu.PROJ_ID, bu.PROJ_NAME, bu.BU_FLG };

        //        switch (getBUListByCondition)
        //        {
        //            case "1":
        //                BU_User_Details = BU_User_Details.Where(s => s.BU_FLG == "1");
        //                break;
        //            case "0":
        //                BU_User_Details = BU_User_Details.Where(s => s.BU_FLG == "0");
        //                break;
        //        }
        //        foreach (var item in BU_User_Details)
        //        {
        //            var model = new BUViewModel()
        //            {
        //                BUId = item.BU_ID,
        //                BUName = item.BU_NAME,
        //                BUType = item.BU_TYPE,
        //                DUName = item.DU_NAME,
        //                ProjectId = item.PROJ_ID,
        //                ProjectName = item.PROJ_NAME,
        //                ContactName = item.FST_NAME + " " + item.LAST_NAME,
        //                EMAIL_ADDR = item.EMAIL_ADDR,
        //                PHONE_NO = item.PHONE_NO,
        //                BU_Flag = item.BU_FLG
        //            };
        //            list.Add(model);
        //        }
        //        if (Request.IsAjaxRequest())
        //        {
        //            return Json(list, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return View("GetAllBU", list);
        //        }
        //    }
        //    return RedirectToAction("Login2", "Home");
        //}
        private void GetAction()
        {
            var ActionList = new SelectList(new[]
            {
                new { ID = "-1", Name = "All" },
                new { ID = "1", Name = "Active" },
                new { ID = "0", Name = "Inactive" },
            },
            "ID", "Name", 1);
            ViewBag.ActionList = ActionList;
        }

        //List of Customer 
        public ActionResult OrgEdit(string getBUListByCondition = "1")
        {
            List<M_ORG_EXT> list = new List<M_ORG_EXT>();
            GetAction();
            if (Session["Admin"] != null)
            {

                var Survey_Details = from bu in db.M_ORG_EXT
                                     join contact in db.M_CONTACT on bu.BU_ID equals contact.BU_ID
                                     orderby bu.CREATED_DT descending
                                     select new { contact.FST_NAME, contact.LAST_NAME, contact.EMAIL_ADDR, contact.PHONE_NO, bu.BU_ID, bu.NAME, bu.LOC, bu.RATING, bu.M_BU.PROJ_NAME, bu.M_BU.PROJ_ID, bu.ACTIVE_FLG };

                switch (getBUListByCondition)
                {
                    case "1":
                        Survey_Details = Survey_Details.Where(s => s.ACTIVE_FLG == "1");
                        break;
                    case "0":
                        Survey_Details = Survey_Details.Where(s => s.ACTIVE_FLG == "0");
                        break;
                }

                var res = db.M_ORG_EXT.ToList();
             

                return View(res);
                }
                if (Request.IsAjaxRequest())
                {
                    return Json(list, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return View("OrgEdit", list);
                }
        
        }

       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
