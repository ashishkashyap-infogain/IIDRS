using IIDRS.Models;
using IIDRS.ViewModel;
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


        private void GetQuarter()
        {
            var quarters = new SelectList(new[]
            {
                new { ID = "-1", Name = "Select" },
                new { ID = "Q1", Name = "Quarter 1" },
                new { ID = "Q2", Name = "Quarter 2" },
                new { ID = "Q3", Name = "Quarter 3" },
                new { ID = "Q4", Name = "Quarter 4" }
            },
            "ID", "Name", 1);
            ViewBag.Quarter = quarters;
            var currentYear = DateTime.Now.Year;

            var years = new SelectList(new[]
            {
                //new { ID = "-1", Name = "Select" },
                new { ID = currentYear.ToString(), Name = currentYear.ToString() },
                new { ID = (currentYear-1).ToString(), Name = (currentYear-1).ToString()}
            },
            "ID", "Name", 1);
            ViewBag.Years = years;
        }
        // GET: Survey
        public ActionResult Index()
        {
            if (Session["CustId"] != null)
            {
                GetQuarter();
                Session["DS"] = "active";
                Session["ES"] = null;
                var res = db.M_CUST_SURVEY
                .Where(x => x.CUST_SURVEY_NAME == "DELIVERY MANAGEMENT").ToList();
                return View(res);
            }
            return RedirectToAction("Login2", "Home");
        }

        [HttpPost]
        public void Save(List<string> surveyIds, List<string> selectedrating, string quarter)//FormCollection form)
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
                        m_ORG_EXT.Survey_Period = quarter;

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
                GetQuarter();
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
        public ActionResult DeliveryQuestion()
        {
            if (Session["Admin"] != null)
            {

                ViewBag.Del = "Questionnaire - Delivery Management";

                var res = db.M_CUST_SURVEY
                .Where(x => x.CUST_SURVEY_NAME == "DELIVERY MANAGEMENT")
                .AsEnumerable()
                .Select(x => x.SURVEY_QUESTION_NAME)
                .Distinct()
                .ToList();
                ViewBag.SurveyQuestionCategory = new SelectList(res.Select(x => new SurveyQuestionCategoryViewModel() { ROW_ID = x, SURVEY_QUESTION_NAME = x }), "SURVEY_QUESTION_NAME", "SURVEY_QUESTION_NAME");
                return View();
            }
            return RedirectToAction("Login2", "Home");
        }
        public ActionResult ExectiveQuestion()
        {
            if (Session["Admin"] != null)
            {

                ViewBag.Del = "Questionnaire - Executive Management";
                var res = db.M_CUST_SURVEY
                .Where(x => x.CUST_SURVEY_NAME == "EXECUTIVE MANAGEMENT")
                .Distinct()
                .AsEnumerable()
                .Select(x => x.SURVEY_QUESTION_NAME)
                .Distinct()
                .ToList();

                ViewBag.SurveyQuestionCategory = new SelectList(res.Select(x => new SurveyQuestionCategoryViewModel() { ROW_ID = x, SURVEY_QUESTION_NAME = x }), "SURVEY_QUESTION_NAME", "SURVEY_QUESTION_NAME");
                return View();
            }
            return RedirectToAction("Login2", "Home");
        }
        [HttpPost]
        public ActionResult CreateExecQuestion(SurveyQuestionViewModel surveyQuestionViewModel)
        {
            if (Session["Admin"] != null)
            {
                if (CreateSurveyQuestion(surveyQuestionViewModel, "EXECUTIVE MANAGEMENT"))
                    return RedirectToAction("SurveyManage");
                else
                    return RedirectToAction("ExectiveQuestion");
            }
            return RedirectToAction("Login2", "Home");
        }

        [HttpPost]
        public ActionResult CreateDeliveryQuestion(SurveyQuestionViewModel surveyQuestionViewModel)
        {
            if (Session["Admin"] != null)
            {
                if (CreateSurveyQuestion(surveyQuestionViewModel, "DELIVERY MANAGEMENT"))
                    return RedirectToAction("SurveyManage");
                else
                    return RedirectToAction("DeliveryQuestion");
            }
            return RedirectToAction("Login2", "Home");
        }

        private bool CreateSurveyQuestion(SurveyQuestionViewModel surveyQuestionViewModel, string type)
        {
            try
            {
                if (!string.IsNullOrEmpty(surveyQuestionViewModel.SURVEY_QUESTION_DESC))
                {
                    var sess = Session["Admin"].ToString();
                    M_PARTY m_PARTY = new M_PARTY();
                    //for alphanumeric PARTY_TYPE_CD
                    var checks = db.M_PARTY.Where(x => x.PARTY_TYPE_CD.Contains("@ QSURVEY")).ToList();
                    m_PARTY.PARTY_TYPE_CD = checks.Max(x => x.PARTY_TYPE_CD);

                    if (m_PARTY.PARTY_TYPE_CD == "0" || m_PARTY.PARTY_TYPE_CD == null)
                    {
                        m_PARTY.PARTY_TYPE_CD = "1-1QSURVEY";
                    }
                    else
                    {
                        StringBuilder sb1 = new StringBuilder();
                        var res1 = Regex.Split(m_PARTY.PARTY_TYPE_CD, @"QSURVEY");
                        var chng1 = res1[0].ToString().Split('-');
                        var inc1 = ((Convert.ToInt32(chng1[1])) + 1).ToString();

                        sb1.Append("1-" + inc1 + "QSURVEY");
                        m_PARTY.PARTY_TYPE_CD = sb1.ToString();

                    }
                    //for alphanumeric PARTY_UID

                    var checks1 = db.M_PARTY.Where(x => x.PARTY_UID.Contains("S")).ToList();
                    m_PARTY.PARTY_UID = checks1.Max(x => x.PARTY_UID);
                    if (m_PARTY.PARTY_UID == "0" || m_PARTY.PARTY_UID == null)
                    {
                        m_PARTY.PARTY_UID = "1-1S";
                    }
                    else
                    {
                        StringBuilder sb2 = new StringBuilder();
                        var res2 = Regex.Split(m_PARTY.PARTY_UID, @"S");
                        var chng2 = res2[0].ToString().Split('-');
                        var inc2 = (Convert.ToInt32(chng2[1]) + 1).ToString();
                        sb2.Append("1-" + inc2 + "S");
                        m_PARTY.PARTY_UID = sb2.ToString();
                    }
                    m_PARTY.TRANS_FLG = "1";
                    m_PARTY.CREATED_DT = System.DateTime.Now;
                    m_PARTY.LAST_UPD_DT = System.DateTime.Now;
                    m_PARTY.ACTIVE_FLG = "1";


                    M_CUST_SURVEY m_CUST_SURVEY = new M_CUST_SURVEY();
                    m_CUST_SURVEY.SURVEY_QUESTION_NAME = surveyQuestionViewModel.SURVEY_QUESTION_NAME;
                    m_CUST_SURVEY.SURVEY_QUESTION_DESC = surveyQuestionViewModel.SURVEY_QUESTION_DESC;
                    m_CUST_SURVEY.ROW_ID = db.M_CUST_SURVEY.Max(x => x.ROW_ID);

                    //for alphanumeric user id   
                    var res = Regex.Split(m_CUST_SURVEY.ROW_ID, @"\D+");

                    if (m_CUST_SURVEY.ROW_ID == "0" || m_CUST_SURVEY.ROW_ID == null)
                    {
                        m_CUST_SURVEY.ROW_ID = "1-1D";
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder("1-");
                        var chng = res[1].ToString();
                        var inc = (Convert.ToInt32(chng) + 1).ToString();
                        sb.Append(inc + "D");
                        m_CUST_SURVEY.ROW_ID = sb.ToString();
                    }

                    var checksPersonUID = db.M_CUST_SURVEY.Where(x => x.SURVEY_ID.Contains("SU")).ToList();
                    m_CUST_SURVEY.SURVEY_ID = checksPersonUID.Max(x => x.SURVEY_ID);

                    res = Regex.Split(m_CUST_SURVEY.SURVEY_ID, @"\SU+");

                    if (m_CUST_SURVEY.SURVEY_ID == "0" || m_CUST_SURVEY.SURVEY_ID == null)
                    {
                        m_CUST_SURVEY.SURVEY_ID = "1-1SU1";
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder("1-");
                        var chng = res[1].ToString();
                        var inc = (Convert.ToInt32(chng) + 1).ToString();
                        sb.Append(inc + "SU");
                        m_CUST_SURVEY.SURVEY_ID = sb.ToString();
                    }
                    m_CUST_SURVEY.CUST_SURVEY_NAME = type;
                    m_CUST_SURVEY.SURVEY_FLG = "1";

                    m_CUST_SURVEY.CREATED_DT = System.DateTime.Now;
                    m_CUST_SURVEY.LAST_UPD_DT = System.DateTime.Now;
                    m_CUST_SURVEY.CREATED_BY = sess;
                    m_CUST_SURVEY.LAST_UPD_BY = sess;
                    m_CUST_SURVEY.PAR_ROW_ID = m_PARTY.PARTY_TYPE_CD;
                    db.M_PARTY.Add(m_PARTY);
                    db.M_CUST_SURVEY.Add(m_CUST_SURVEY);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}