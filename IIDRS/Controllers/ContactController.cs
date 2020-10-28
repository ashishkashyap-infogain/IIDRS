using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                //ViewBag.count = 4;
                var res = db.M_CONTACT.ToList().Where(x => x.ACTIVE_FLG == "1").OrderByDescending(x => x.CREATED_DT);
                return View("Index",res);
            }
            return RedirectToAction("Login2", "Home");
        }
        [HttpPost]
        public ActionResult Create(M_CONTACT contact)
        {
            if (Session["Admin"] != null)
            {

                var sess = Session["Admin"].ToString();
                //if (!ModelState.IsValid)
                //{
                //    var c = new M_CONTACT();
                //    return View("Index", c);
                //}

                //if(contact.FST_NAME==null)
                // {
                //     Delete();
                // }
                    
                //for alphanumeric PERSON_UID

                var checksPersonUID = db.M_CONTACT.Where(x => x.PERSON_UID.Contains("KCONTACT")).ToList();
                contact.PERSON_UID = checksPersonUID.Max(x => x.PERSON_UID);

                var res = Regex.Split(contact.PERSON_UID, @"\D+");

                if (contact.PERSON_UID == "0" || contact.PERSON_UID == null)
                {
                    contact.PERSON_UID = "2-1CONTACT";
                }
                else
                {
                    StringBuilder sb = new StringBuilder("1-");
                    var chng = res[1].ToString();
                    var inc = (Convert.ToInt32(chng) + 1).ToString();
                    sb.Append(inc + "KCONTACT");
                    contact.PERSON_UID = sb.ToString();
                }

                //for alphanumeric PAR_ROW_ID
                //var checksPARROWID = db.M_CONTACT.Where(x => x.PAR_ROW_ID.Contains("CONTACT")).ToList();
                //contact.PERSON_UID = checksPARROWID.Max(x => x.PAR_ROW_ID);

                //var res1 = Regex.Split(contact.PERSON_UID, @"\D+");

                //if (contact.PERSON_UID == "0" || contact.PERSON_UID == null)
                //{
                //    contact.PERSON_UID = "2-1CONTACT";
                //}
                //else
                //{
                //    StringBuilder sb = new StringBuilder("1-");
                //    var chng = res[1].ToString();
                //    var inc = (Convert.ToInt32(chng) + 1).ToString();
                //    sb.Append(inc + "CONTACT");
                //    contact.PERSON_UID = sb.ToString();
                //}

                //contact.PERSON_UID = "1-22JCONTACT";
                M_PARTY m_PARTY = new M_PARTY();

                //for alphanumeric PARTY_TYPE_CD
                var checks = db.M_PARTY.Where(x => x.PARTY_TYPE_CD.Contains("CONTACT")).ToList();
                m_PARTY.PARTY_TYPE_CD = checks.Max(x => x.PARTY_TYPE_CD);

                if (m_PARTY.PARTY_TYPE_CD == "0" || m_PARTY.PARTY_TYPE_CD == null)
                {
                    m_PARTY.PARTY_TYPE_CD = "1-1CONTACT";
                }
                else
                {
                    StringBuilder sb1 = new StringBuilder();
                    var res1 = Regex.Split(m_PARTY.PARTY_TYPE_CD, @"CONTACT");
                    var chng1 = res1[0].ToString().Split('-');
                    var inc1 = ((Convert.ToInt32(chng1[1])) + 1).ToString();

                    sb1.Append("1-" + inc1 + "CONTACT");
                    m_PARTY.PARTY_TYPE_CD = sb1.ToString();

                }
                //for alphanumeric PARTY_UID

                var checks1 = db.M_PARTY.Where(x => x.PARTY_UID.Contains("C")).ToList();
                m_PARTY.PARTY_UID = checks1.Max(x => x.PARTY_UID);
                if (m_PARTY.PARTY_UID == "0" || m_PARTY.PARTY_UID == null)
                {
                    m_PARTY.PARTY_UID = "1-1C";
                }
                else
                {
                    StringBuilder sb2 = new StringBuilder();
                    var res2 = Regex.Split(m_PARTY.PARTY_UID, @"C");
                    var chng2 = res2[0].ToString().Split('-');
                    var inc2 = (Convert.ToInt32(chng2[1]) + 1).ToString();
                    sb2.Append("1-" + inc2 + "C");
                    m_PARTY.PARTY_UID = sb2.ToString();
                }
                m_PARTY.TRANS_FLG = "1";
                m_PARTY.CREATED_DT = System.DateTime.Now;
                m_PARTY.LAST_UPD_DT = System.DateTime.Now;
                m_PARTY.ACTIVE_FLG = "1";

                //for alphanumeric BU_ID
                M_BU m_bu = new M_BU();
                
                //Contact page properties
                contact.ROW_ID = contact.PERSON_UID;
                contact.FST_NAME = contact.FST_NAME;
                contact.LAST_NAME = contact.LAST_NAME;
                contact.EMAIL_ADDR = contact.EMAIL_ADDR;
                
                contact.CREATED_DT = System.DateTime.Now;
                contact.LAST_UPD_DT = System.DateTime.Now;
                contact.CREATED_BY = sess;
                contact.LAST_UPD_BY = sess;
                
                //contact.BU_ID = "1-11BU";
                //m_USER.PW_LAST_UPD = System.DateTime.Now.ToString();
                //m_USER.CREATED_BY = sess;
                //m_USER.LAST_UPD_BY = sess;
                contact.ACTIVE_FLG = "1";
                //contact.BU_ID = m_bu.BU_ID;
                contact.BU_ID = "1-13BU";
                contact.PAR_ROW_ID = m_PARTY.PARTY_UID;
                contact.EMP_FLG = "1";
                contact.EMP_ID = contact.EMP_ID;
                contact.PHONE_NO = contact.PHONE_NO;

                db.M_PARTY.Add(m_PARTY);
               db.M_CONTACT.Add(contact);
                db.SaveChanges();
               // TempData["successmsg"] = "Inserted successfully";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Contact");

        }

        [HttpPost]
        public ActionResult Edit(M_CONTACT contact)
        {
            if (Session["Admin"] != null)
            {
                var sess = Session["Admin"].ToString();
                //parrowID= db.M_BU.pa
                
                if (contact.PERSON_UID != null)
                {
                    contact.PERSON_UID = contact.PERSON_UID.Trim();
                    var personId = db.M_CONTACT.Where(x => x.PERSON_UID == contact.PERSON_UID).FirstOrDefault();

                    if (personId != null)
                    {
                        // TempData["successmsg"] = "Edited successfully";
                        //return RedirectToAction("Index");
                        //personId.PERSON_UID = contact.PERSON_UID;
                        //personId.ROW_ID = contact.PERSON_UID;

                        contact.FST_NAME = contact.FST_NAME.Trim();
                        contact.LAST_NAME = contact.LAST_NAME.Trim(); 
                        contact.EMAIL_ADDR = contact.EMAIL_ADDR.Trim(); 
                        contact.EMP_ID = contact.EMP_ID.Trim();
                        contact.PHONE_NO = contact.PHONE_NO.Trim();

                        personId.PERSON_UID = contact.PERSON_UID;
                        personId.FST_NAME = contact.FST_NAME;
                        personId.LAST_NAME = contact.LAST_NAME;
                        personId.EMAIL_ADDR = contact.EMAIL_ADDR ;
                        personId.EMP_ID = contact.EMP_ID;
                        personId.PHONE_NO = contact.PHONE_NO;
                        personId.BU_ID = contact.BU_ID;
                        personId.LAST_UPD_DT = System.DateTime.Now;

                        //personId.CREATED_DT = contact.CREATED_DT;
                        //personId.CREATED_BY = contact.CREATED_BY;
                        //personId.LAST_UPD_BY = contact.LAST_UPD_BY;
                        //personId.ACTIVE_FLG = contact.ACTIVE_FLG;
                        //personId.BU_ID = contact.BU_ID;
                        //personId.PAR_ROW_ID = contact.PAR_ROW_ID;
                        //personId.EMP_FLG = contact.EMP_FLG;

                        

                        //db.Entry(contact).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Contact");
        }

        [HttpPost]
        public ActionResult Delete(M_CONTACT id)
        {
            if (Session["Admin"] != null)
            {

                if (id.PERSON_UID != null)
                {
                    id.PERSON_UID = id.PERSON_UID.Trim();
                    M_CONTACT contact = db.M_CONTACT.Find(id.PERSON_UID);
                    contact.ACTIVE_FLG = "0";

                    db.SaveChanges();
                    //TempData["successmsg"] = "Deleted successfully";
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Contact");
        }
    }
}