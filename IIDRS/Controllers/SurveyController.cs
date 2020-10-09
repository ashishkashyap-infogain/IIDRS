using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IIDRS.Controllers
{
    public class SurveyController : Controller
    {
        private DataModel db = new DataModel();

        // GET: Survey
        public ActionResult Index()
        {
            if (Session["CustId"] != null)
            {
                Session["DS"] = "active";
                Session["ES"] = null;
                var res = db.M_CUST_SURVEY
                .Where(x => x.CUST_SURVEY_NAME == "DELIVERY MANAGEMENT").ToList();
                return View(res);
            }
            return RedirectToAction("Login2", "Home");
        }

        [HttpPost]
        public void Save(List<string> surveyIds, List<string> selectedrating)//FormCollection form)
        {
            if (Session["CustId"] != null)
            {
                M_BU m_BU = new M_BU();
                var res = Session["CustId"].ToString();
                try
                {

                    for (var item = 0; item < surveyIds.Count; item++)
                    {
                        //M_PARTY m_PARTY = new M_PARTY();
                        //m_PARTY.PARTY_TYPE_CD = res;
                        //m_PARTY.PARTY_UID = db.M_PARTY.Max(x => x.PARTY_UID) + 1;
                        //m_PARTY.TRANS_FLG = "1";
                        //m_PARTY.CREATED_DT = System.DateTime.Now;
                        //m_PARTY.LAST_UPD_DT = System.DateTime.Now;
                        //m_PARTY.ACTIVE_FLG = "1";

                        M_ORG_EXT m_ORG_EXT = new M_ORG_EXT();
                        //m_ORG_EXT.ROW_ID = "new123";
                       
                        var rowID ="2-"+Convert.ToString(Convert.ToInt32( db.M_ORG_EXT.Max(x => x.ROW_ID).Split('-')[1].Split('E')[0])+1)+"EORGEXT";
                        m_ORG_EXT.ROW_ID = rowID;
                        m_ORG_EXT.CREATED_DT = DateTime.Now;
                        m_ORG_EXT.ACCNT_FLG = "1";
                        m_ORG_EXT.ACTIVE_FLG = "1";
                        m_ORG_EXT.BU_ID = "1-1BU";
                        m_ORG_EXT.CREATED_BY = res;
                        //m_ORG_EXT.PAR_ROW_ID = m_PARTY.PARTY_UID;
                        m_ORG_EXT.SURVEY_ID = surveyIds[item];
                        m_ORG_EXT.RATING = selectedrating[item];


                        //m_ORG_EXT.NAME = "Admin";
                        //m_ORG_EXT.LOC = "USA";
                        //m_ORG_EXT.PAR_ROW_ID = rowID;
                        //m_ORG_EXT.PAR_BU_ID = "1-6BU";
                        //m_ORG_EXT.PR_ADDR_ID = "1-5ADDRPER";
                        //m_ORG_EXT.PR_CON_ID = "1-5CONTACT";
                        //m_ORG_EXT.PR_POSTN_ID = "1-5POST";
                        //m_ORG_EXT.ZIPCODE = "00000";
                        m_ORG_EXT.LAST_UPD_BY = res;




                        db.M_ORG_EXT.Add(m_ORG_EXT);
                        db.SaveChanges();
                        continue;
                    }

                }
                catch (Exception e)
                {
                }
            }
            RedirectToAction("Thankyou");
        }
        public ActionResult Thankyou()
        {
            if (Session["CustId"] != null)
            {
                return View();
            }
            return RedirectToAction("Login2", "Home");
        }

        // GET: Survey
        public ActionResult ExIndex()
        {
            if (Session["CustId"] != null)
            {
                Session["DS"] = null;
                Session["ES"] = "active";
                var res = db.M_CUST_SURVEY
                .Where(x => x.CUST_SURVEY_NAME == "EXECUTIVE MANAGEMENT").ToList();
                return View(res);
            }
            return RedirectToAction("Login2", "Home");
        }

        public ActionResult SurveyManage()
        {
            if (Session["Admin"] != null)
            {

                ViewBag.Del = "Questionnaire - Delivery Management";

                var res = db.M_CUST_SURVEY
                .Where(x => x.CUST_SURVEY_NAME == "DELIVERY MANAGEMENT").ToList();
                return View(res);
            }
            return RedirectToAction("Login2", "Home");
        }
        public ActionResult SurveyExec()
        {
            if (Session["Admin"] != null)
            {

                ViewBag.Del = "Questionnaire - Executive Management";

                var res = db.M_CUST_SURVEY
                .Where(x => x.CUST_SURVEY_NAME == "EXECUTIVE MANAGEMENT").ToList();
                return View("SurveyManage", res);
            }
            return RedirectToAction("Login2", "Home");
        }
    }
}