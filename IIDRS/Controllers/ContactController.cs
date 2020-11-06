using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using IIDRS.ViewModel;

namespace IIDRS.Controllers
{
    public class ContactController : Controller
    {
        private DataModel db = new DataModel();
        // GET: Contact
        public ActionResult Index()
        {
                List<ContactViewModel> list = new List<ContactViewModel>();

                if (Session["Admin"] != null)
                {

                    var Contact_User_Details = from contact in db.M_CONTACT
                                          join bu in db.M_BU on contact.BU_ID equals bu.BU_ID
                                          where contact.ACTIVE_FLG == "1"
                                          orderby contact.CREATED_DT descending
                                          select new {contact.EMP_ID, contact.FST_NAME, contact.LAST_NAME, contact.EMAIL_ADDR, contact.PHONE_NO,contact.ACTIVE_FLG,contact.LAST_UPD_DT, bu.BU_NAME,bu.DU_NAME,  bu.PROJ_NAME};

                    foreach (var item in Contact_User_Details)
                    {
                        var model = new ContactViewModel()
                        {
                            EMP_ID=item.EMP_ID,
                            FST_NAME=item.FST_NAME,
                            LAST_NAME=item.LAST_NAME,
                            EMAIL_ADDR=item.EMAIL_ADDR,
                            PHONE_NO = item.PHONE_NO,
                            ACTIVE_FLG=item.ACTIVE_FLG,
                            BU_NAME = item.BU_NAME,      
                            DU_NAME = item.DU_NAME,
                            PROJ_NAME = item.PROJ_NAME,
                            LAST_UPD_DT=item.LAST_UPD_DT.ToString(),
                        };
                        list.Add(model);
                    }
                    return View("Index",list);
            }
            return RedirectToAction("Login2", "Home");
        }
        [HttpPost]
        public ActionResult Create(ContactViewModel contactViewModel)
        {
            if (Session["Admin"] != null)
            {

                var session = Session["Admin"].ToString();

                //for alphanumeric Employee iD
                var checksEmpID = db.M_CONTACT.Where(x => x.EMP_ID.Contains("1")).ToList();
                contactViewModel.EMP_ID = checksEmpID.Max(x => x.EMP_ID);
                var emp = (Convert.ToInt32(contactViewModel.EMP_ID) + 1).ToString();
                contactViewModel.EMP_ID = emp.ToString();

                //for alphanumeric PERSON_UID

                var checksPersonUID = db.M_CONTACT.Where(x => x.PERSON_UID.Contains("KCONTACT")).ToList();
                contactViewModel.PERSON_UID = checksPersonUID.Max(x => x.PERSON_UID);

                var res = Regex.Split(contactViewModel.PERSON_UID, @"\D+");

                if (contactViewModel.PERSON_UID == "0" || contactViewModel.PERSON_UID == null)
                {
                    contactViewModel.PERSON_UID = "2-1CONTACT";
                }
                else
                {
                    StringBuilder sb = new StringBuilder("1-");
                    var chng = res[1].ToString();
                    var inc = (Convert.ToInt32(chng) + 1).ToString();
                    sb.Append(inc + "KCONTACT");
                    contactViewModel.PERSON_UID = sb.ToString();
                }

                //for alphanumeric PAR_ROW_ID

                var checksParID = db.M_CONTACT.Where(x => x.PAR_ROW_ID.Contains("CONTACT")).ToList();
                contactViewModel.PAR_ROW_ID = checksPersonUID.Max(x => x.PAR_ROW_ID);

                var respar = Regex.Split(contactViewModel.PAR_ROW_ID, @"\D+");

                if (contactViewModel.PAR_ROW_ID == "0" || contactViewModel.PAR_ROW_ID == null)
                {
                    contactViewModel.PAR_ROW_ID = "2-1CONTACT";
                }
                else
                {
                    StringBuilder sb = new StringBuilder("1-");
                    var chng = respar[1].ToString();
                    var inc = (Convert.ToInt32(chng) + 1).ToString();
                    sb.Append(inc + "KCONTACT");
                    contactViewModel.PAR_ROW_ID = sb.ToString();
                }

                //for alphanumeric ROW_ID

                var checksRowID = db.M_CONTACT.Where(x => x.ROW_ID.Contains("KCONTACT")).ToList();
                contactViewModel.ROW_ID = checksPersonUID.Max(x => x.ROW_ID);

                var resrow = Regex.Split(contactViewModel.ROW_ID, @"\D+");

                if (contactViewModel.ROW_ID == "0" || contactViewModel.ROW_ID == null)
                {
                    contactViewModel.ROW_ID = "2-1CONTACT";
                }
                else
                {
                    StringBuilder sb = new StringBuilder("1-");
                    var chng = resrow[1].ToString();
                    var inc = (Convert.ToInt32(chng) + 1).ToString();
                    sb.Append(inc + "KCONTACT");
                    contactViewModel.ROW_ID = sb.ToString();
                }

                //for alphanumeric BU_ID

                var checksbuID = db.M_CONTACT.Where(x => x.BU_ID.Contains("1BU")).ToList();
                contactViewModel.BU_ID = checksPersonUID.Max(x => x.BU_ID);

                var resbuid = Regex.Split(contactViewModel.BU_ID, @"\D+");

                if (contactViewModel.BU_ID == "0" || contactViewModel.BU_ID == null)
                {
                    contactViewModel.BU_ID = "2-1BU";
                }
                else
                {
                    StringBuilder sb = new StringBuilder("1-");
                    var chng = resbuid[1].ToString();
                    var inc = (Convert.ToInt32(chng) + 1).ToString();
                    sb.Append(inc + "BU");
                    contactViewModel.BU_ID = sb.ToString();
                }
                //contact.PERSON_UID = "1-22JCONTACT";
                M_PARTY m_PARTY = new M_PARTY();

                //for alphanumeric PARTY_TYPE_CD
                var checks = db.M_PARTY.Where(x => x.PARTY_TYPE_CD.Contains("KCONTACT")).ToList();
                m_PARTY.PARTY_TYPE_CD = checks.Max(x => x.PARTY_TYPE_CD);

                if (m_PARTY.PARTY_TYPE_CD == "0" || m_PARTY.PARTY_TYPE_CD == null)
                {
                    m_PARTY.PARTY_TYPE_CD = "1-1CONTACT";
                }
                else
                {
                    StringBuilder sb1 = new StringBuilder();
                    var res1 = Regex.Split(m_PARTY.PARTY_TYPE_CD, @"KCONTACT");
                    var chng1 = res1[0].ToString().Split('-');
                    var inc1 = ((Convert.ToInt32(chng1[1])) + 1).ToString();

                    sb1.Append("1-" + inc1 + "KCONTACT");
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

                  
                
                //Start contact Details
                AddContactDetails(contactViewModel, session);

                //BU Details 
                var buDetails = GetBUDetails(contactViewModel.BU_ID);

                //create personId
                var res0 = Regex.Split(contactViewModel.BU_ID, @"\D+");

                
                    //Create rowId
                    StringBuilder sbRowId = new StringBuilder();
                var chng01 = res0[1].ToString();
                Random rnd = new Random();
                char randomChar = (char)rnd.Next('A', 'Z');
                var inc01 = (Convert.ToInt32(chng01) + 1).ToString();
                sbRowId.Append("2-" + inc01 + randomChar + "BBU");

                //Create rowId
                StringBuilder sbParRowId = new StringBuilder();
                var chng02 = res0[1].ToString();
                Random rnd1 = new Random();
                char randomChar1 = (char)rnd.Next('A', 'Z');
                var inc02 = (Convert.ToInt32(chng01) + 1).ToString();
                sbParRowId.Append("2-" + inc02 + randomChar1 + "BUPARBU");

                

                //db.M_BU.Add(m_BU);
                db.M_PARTY.Add(m_PARTY);
                // db.M_CONTACT.Add(contact);
                AddBUDetails(buDetails, sbRowId.ToString(), session, sbParRowId.ToString(),contactViewModel.BU_ID);
                db.SaveChanges();
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
                
                
                if (contact.EMP_ID != null)
                {
                    contact.EMP_ID = contact.EMP_ID.Trim();
                    var personId = db.M_CONTACT.Where(x => x.EMP_ID == contact.EMP_ID).FirstOrDefault();

                    if (personId != null)
                    {
                     

                        contact.FST_NAME = contact.FST_NAME.Trim();
                        contact.LAST_NAME = contact.LAST_NAME.Trim(); 
                        contact.EMAIL_ADDR = contact.EMAIL_ADDR.Trim(); 
                        contact.PHONE_NO = contact.PHONE_NO.Trim();

                        personId.FST_NAME = contact.FST_NAME;
                        personId.LAST_NAME = contact.LAST_NAME;
                        personId.EMAIL_ADDR = contact.EMAIL_ADDR ;
                        personId.EMP_ID = contact.EMP_ID;
                        personId.PHONE_NO = contact.PHONE_NO;
                        personId.LAST_UPD_DT = System.DateTime.Now;

                        personId.BU_ID = contact.BU_ID;
                        personId.M_BU.BU_NAME = contact.M_BU.BU_NAME;
                        personId.M_BU.DU_NAME = contact.M_BU.DU_NAME;
                        personId.M_BU.PROJ_NAME = contact.M_BU.PROJ_NAME;
                      

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

                if (id.EMP_ID != null)
                {
                    id.EMP_ID = id.EMP_ID.Trim();
                    //M_CONTACT contact = db.M_CONTACT.Find(id.PERSON_UID);

                    var personData = db.M_CONTACT.Where(x => x.EMP_ID == id.EMP_ID).FirstOrDefault();
                    personData.ACTIVE_FLG = "0";

                    db.SaveChanges();
                    //TempData["successmsg"] = "Deleted successfully";
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Contact");
        }

        public M_BU GetBUDetails(string buId)
        {
            try
            {
                var buDetails = db.M_BU.FirstOrDefault(m => m.BU_ID == buId);
                return buDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public JsonResult BUDetails()
        {
            try
            {
                var list = db.M_BU.ToList().Select(m => new
                {
                    buId = m.BU_ID,
                    buName = m.BU_NAME,
                    //duName = m.DU_NAME,
                    //projectName = m.PROJ_NAME,

                }).ToList();
                ViewBag.BuDetailList = list;
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult GetDU(string buId)
        {
            try
            {
                var bu = GetBUDetails(buId);
                var details = new
                {
                    //bu.BU_NAME,
                    bu.DU_NAME,
                    bu.PROJ_NAME

                };
                ViewBag.DuDetailList = details;
                return Json(details, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public M_BU GetBUtDetails(string buId)
        {
            try
            {
                var buDetails = db.M_BU.FirstOrDefault(m => m.BU_ID == buId);
                return buDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public JsonResult DUDetails()
        //{
        //    try
        //    {
        //        var list = db.M_BU.ToList().Select(m => new
        //        {
        //            buId = m.BU_ID,
        //            duName = m.DU_NAME,                   

        //        }).ToList();
        //        ViewBag.DuDetailList = list;
        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        private void AddBUDetails(M_BU buDetails, string rowId, string createdBy,string parRowId,string buid)
        {
            try
            {
                M_BU m_BU = new M_BU();
                m_BU.ROW_ID = rowId;
                m_BU.CREATED_BY = createdBy;
                m_BU.CREATED_DT = System.DateTime.Now;
                m_BU.LAST_UPD_BY = null;
                m_BU.LAST_UPD_DT = System.DateTime.Now;
                m_BU.BU_ID = buid;
                m_BU.BU_NAME = buDetails.BU_NAME;
                m_BU.BU_TYPE = buDetails.BU_TYPE;
                m_BU.DU_NAME = buDetails.DU_NAME;
                m_BU.PROJ_ID = buDetails.PROJ_ID;
                m_BU.PROJ_NAME = buDetails.PROJ_NAME;
                m_BU.BU_FLG = "1";
                m_BU.PAR_BU_ID = buDetails.PAR_BU_ID;
                m_BU.PAR_ROW_ID = parRowId;
                db.M_BU.Add(m_BU);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddContactDetails(ContactViewModel ViewModel, string createdBy)
        {
            try
            {
                M_CONTACT m_CONTACT = new M_CONTACT();
                m_CONTACT.PERSON_UID = ViewModel.PERSON_UID;
                m_CONTACT.ACTIVE_FLG ="1";
                m_CONTACT.EMAIL_ADDR = ViewModel.EMAIL_ADDR;
                m_CONTACT.EMP_FLG = "1";
                m_CONTACT.EMP_ID = ViewModel.EMP_ID;
                m_CONTACT.FST_NAME = ViewModel.FST_NAME;
                m_CONTACT.LAST_NAME = ViewModel.LAST_NAME;
                m_CONTACT.LAST_UPD_BY = null;
                m_CONTACT.LAST_UPD_DT = System.DateTime.Now;
                m_CONTACT.CREATED_BY = createdBy;
                m_CONTACT.CREATED_DT = DateTime.UtcNow;
                m_CONTACT.PAR_ROW_ID = ViewModel.PAR_ROW_ID;
                m_CONTACT.PHONE_NO = ViewModel.PHONE_NO;
                m_CONTACT.BU_ID = ViewModel.BU_ID;
                m_CONTACT.ROW_ID = ViewModel.ROW_ID;
                db.M_CONTACT.Add(m_CONTACT);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}