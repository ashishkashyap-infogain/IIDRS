using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace IIDRS.Controllers
{
    public class AuthorizationController : Controller
    {

        private DataModel db = new DataModel();
        // GET: Authorization
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            if (Session["Admin"] != null)
            {
                List<string> ls = new List<string>()
                {
                    "Admin","Customer"
                };
                var m_USER = db.M_USER.Where(x => x.USER_FLG == "1").OrderByDescending(x => x.CREATED_DT);
                ViewBag.Login_Domain = new SelectList(ls);
                return View("Index2", m_USER.ToList());
            }
            return RedirectToAction("Login2", "Home");
        }

        [HttpPost]
        public ActionResult Create(M_USER m_USER)
        {
            if (Session["Admin"] != null)
            {

                var sess = Session["Admin"].ToString();

                M_PARTY m_PARTY = new M_PARTY();

                //for alphanumeric PARTY_TYPE_CD
                var checks = db.M_PARTY.Where(x => x.PARTY_TYPE_CD.Contains("USER")).ToList();
                m_PARTY.PARTY_TYPE_CD = checks.Max(x => x.PARTY_TYPE_CD);

                if (m_PARTY.PARTY_TYPE_CD == "0" || m_PARTY.PARTY_TYPE_CD == null)
                {
                    m_PARTY.PARTY_TYPE_CD = "1-1USER";
                }
                else
                {
                    StringBuilder sb1 = new StringBuilder();
                    var res1 = Regex.Split(m_PARTY.PARTY_TYPE_CD, @"USER");
                    var chng1 = res1[0].ToString().Split('-');
                    var inc1 = ((Convert.ToInt32(chng1[1])) + 1).ToString();

                    sb1.Append("1-" + inc1 + "USER");
                    m_PARTY.PARTY_TYPE_CD = sb1.ToString();

                }
                //for alphanumeric PARTY_UID

                var checks1 = db.M_PARTY.Where(x => x.PARTY_UID.Contains("G")).ToList();
                m_PARTY.PARTY_UID = checks1.Max(x => x.PARTY_UID);
                if (m_PARTY.PARTY_UID == "0" || m_PARTY.PARTY_UID == null)
                {
                    m_PARTY.PARTY_UID = "1-1G";
                }
                else
                {
                    StringBuilder sb2 = new StringBuilder();
                    var res2 = Regex.Split(m_PARTY.PARTY_UID, @"G");
                    var chng2 = res2[0].ToString().Split('-');
                    var inc2 = (Convert.ToInt32(chng2[1]) + 1).ToString();
                    sb2.Append("1-" + inc2 + "G");
                    m_PARTY.PARTY_UID = sb2.ToString();
                }
                m_PARTY.TRANS_FLG = "1";
                m_PARTY.CREATED_DT = System.DateTime.Now;
                m_PARTY.LAST_UPD_DT = System.DateTime.Now;
                m_PARTY.ACTIVE_FLG = "1";


                m_USER.USER_ID = db.M_USER.Max(x => x.USER_ID);

                //for alphanumeric user id   
                var res = Regex.Split(m_USER.USER_ID, @"\D+");

                if (m_USER.USER_ID == "0" || m_USER.USER_ID == null)
                {
                    m_USER.USER_ID = "1-1GUSER";
                }
                else
                {


                    StringBuilder sb = new StringBuilder("1-");
                    var chng = res[1].ToString();
                    var inc = (Convert.ToInt32(chng) + 1).ToString();
                    sb.Append(inc + "GUSER");
                    m_USER.USER_ID = sb.ToString();
                }
                m_USER.CREATED_DT = System.DateTime.Now;
                m_USER.LAST_UPD_DT = System.DateTime.Now;
                m_USER.PW_LAST_UPD = System.DateTime.Now.ToString();
                m_USER.CREATED_BY = sess;
                m_USER.LAST_UPD_BY = sess;
                m_USER.USER_FLG = "1";
                m_USER.PAR_ROW_ID = m_PARTY.PARTY_TYPE_CD;
                db.M_PARTY.Add(m_PARTY);
                db.M_USER.Add(m_USER);
                db.SaveChanges();
                return RedirectToAction("Index2");
            }
            return RedirectToAction("Login2", "Home");
        }

        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(M_USER id)
        {
            if (Session["Admin"] != null)
            {

                if (id.USER_ID != null)
                {
                    id.USER_ID = id.USER_ID.Trim();
                    M_USER m_USER = db.M_USER.Find(id.USER_ID);
                    m_USER.USER_FLG = "0";
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login2", "Home");
        }
        [HttpPost]
        public ActionResult Edit(M_USER m_USER)
        {
            if (Session["Admin"] != null)
            {
                var sess = Session["Admin"].ToString();
                if (m_USER.USER_ID != null)
                {
                    m_USER.USER_ID = m_USER.USER_ID.Trim();
                    var userId = db.M_USER.Where(x => x.USER_ID == m_USER.USER_ID).FirstOrDefault();
                    if (userId != null)
                    {
                        m_USER.PASSWORD = m_USER.PASSWORD.Trim();
                        m_USER.LOGIN = m_USER.LOGIN.Trim();
                        m_USER.LOGIN_DOMAIN = m_USER.LOGIN_DOMAIN.Trim();

                        userId.LOGIN = m_USER.LOGIN;
                        userId.LOGIN_DOMAIN = m_USER.LOGIN_DOMAIN;
                        userId.PASSWORD = m_USER.PASSWORD;
                        userId.LAST_UPD_DT = System.DateTime.Now;
                        userId.LAST_UPD_BY = sess;
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login2", "Home");

        }
    }
}