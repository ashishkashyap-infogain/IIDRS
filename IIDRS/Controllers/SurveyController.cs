using IIDRS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace IIDRS.Controllers
{
    public class SurveyController : Controller
    {
        private DataModel db = new DataModel();
        //private IIDRSEntities db = new IIDRSEntities();

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
                try
                {
                    var res = Session["CustId"].ToString();
                    var user = db.Database.SqlQuery<UserDto>("Select * from vw_user where LoginID=@id", new SqlParameter("@id", res)).FirstOrDefault();
                    for (var item = 0; item < surveyIds.Count; item++)
                    {

                        M_PARTY m_PARTY = new M_PARTY();

                        //for alphanumeric PARTY_TYPE_CD
                        var checks = db.M_PARTY.Where(x => x.PARTY_TYPE_CD.Contains("CUSTSURVEY")).ToList();
                        m_PARTY.PARTY_TYPE_CD = checks.Max(x => x.PARTY_TYPE_CD);

                        if (m_PARTY.PARTY_TYPE_CD == "0" || m_PARTY.PARTY_TYPE_CD == null)
                        {
                            m_PARTY.PARTY_TYPE_CD = "1-1CUSTSURVEY";
                        }
                        else
                        {
                            StringBuilder sb1 = new StringBuilder();
                            var res1 = Regex.Split(m_PARTY.PARTY_TYPE_CD, @"CUSTSURVEY");
                            var chng1 = res1[0].ToString().Split('-');
                            var inc1 = ((Convert.ToInt32(chng1[1])) + 1).ToString();

                            sb1.Append("2-" + inc1 + "CUSTSURVEY");
                            m_PARTY.PARTY_TYPE_CD = sb1.ToString();

                        }
                        //for alphanumeric PARTY_UID

                        var checks1 = db.M_PARTY.Where(x => x.PARTY_UID.Contains("D")).ToList();
                        m_PARTY.PARTY_UID = checks1.Max(x => x.PARTY_UID);
                        if (m_PARTY.PARTY_UID == "0" || m_PARTY.PARTY_UID == null)
                        {
                            m_PARTY.PARTY_UID = "1-1D";
                        }
                        else
                        {
                            StringBuilder sb2 = new StringBuilder();
                            var res2 = Regex.Split(m_PARTY.PARTY_UID, @"D");
                            var chng2 = res2[0].ToString().Split('-');
                            var inc2 = (Convert.ToInt32(chng2[1]) + 1).ToString();
                            sb2.Append("2-" + inc2 + "D");
                            m_PARTY.PARTY_UID = sb2.ToString();
                        }
                        m_PARTY.TRANS_FLG = "1";
                        m_PARTY.CREATED_DT = System.DateTime.Now;
                        m_PARTY.LAST_UPD_DT = System.DateTime.Now;
                        m_PARTY.ACTIVE_FLG = "1";


                        M_ORG_EXT m_ORG_EXT = new M_ORG_EXT();

                        var rowID = "2-" + Convert.ToString(Convert.ToInt32(db.M_ORG_EXT.Max(x => x.ROW_ID).Split('-')[1].Split('E')[0]) + 1) + "EORGEXT";


                        m_ORG_EXT.ROW_ID = rowID;
                        m_ORG_EXT.CREATED_DT = DateTime.Now;
                        m_ORG_EXT.LAST_UPD_DT = DateTime.Now;
                        m_ORG_EXT.ACCNT_FLG = "1";
                        m_ORG_EXT.ACTIVE_FLG = "1";
                        m_ORG_EXT.BU_ID = user.BU_ID;
                        m_ORG_EXT.CREATED_BY = res;
                        m_ORG_EXT.PAR_ROW_ID = m_PARTY.PARTY_UID;
                        m_ORG_EXT.SURVEY_ID = surveyIds[item];
                        m_ORG_EXT.RATING = selectedrating[item];
                        m_ORG_EXT.NAME = user.BRAND;                        

                        //m_ORG_EXT.NAME = user.Contact_Person;
                        m_ORG_EXT.LOC = user.Country;
                        m_ORG_EXT.PAR_ROW_ID = rowID;
                        //m_ORG_EXT.PAR_BU_ID = "1-6BU";
                        //m_ORG_EXT.PR_ADDR_ID = "1-5ADDRPER";
                        m_ORG_EXT.PR_CON_ID = user.PERSON_UID;
                        //m_ORG_EXT.PR_POSTN_ID = "1-5POST";
                        m_ORG_EXT.ZIPCODE = user.zipcode;
                        m_ORG_EXT.LAST_UPD_BY = res;


                        db.M_PARTY.Add(m_PARTY);
                        db.M_ORG_EXT.Add(m_ORG_EXT);
                        db.SaveChanges();
                        continue;
                    }
                }
                catch (Exception eX)
                {
                    Console.WriteLine(eX.Message);
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