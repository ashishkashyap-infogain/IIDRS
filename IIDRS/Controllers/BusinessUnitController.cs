﻿using IIDRS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace IIDRS.Controllers
{
    public class BusinessUnitController : Controller
    {
        private DataModel db = new DataModel();
        // GET: BusinessUnit
        public ActionResult GetAllBU(string getBUListByCondition = "1")
        {
            List<BUViewModel> list = new List<BUViewModel>();
            GetAction();
            if (Session["Admin"] != null)
            {

                var BU_User_Details = from bu in db.M_BU
                                      join contact in db.M_CONTACT on bu.BU_ID equals contact.BU_ID
                                      orderby bu.CREATED_DT descending
                                      select new { contact.FST_NAME, contact.LAST_NAME, contact.EMAIL_ADDR, contact.PHONE_NO, bu.BU_NAME, bu.BU_ID, bu.BU_TYPE, bu.DU_NAME, bu.PROJ_ID, bu.PROJ_NAME, bu.BU_FLG };

                switch (getBUListByCondition)
                {
                    case "1":
                        BU_User_Details = BU_User_Details.Where(s => s.BU_FLG == "1");
                        break;
                    case "0":
                        BU_User_Details = BU_User_Details.Where(s => s.BU_FLG == "0");
                        break;
                }
                foreach (var item in BU_User_Details)
                {
                    var model = new BUViewModel()
                    {
                        BUId = item.BU_ID,
                        BUName = item.BU_NAME,
                        BUType = item.BU_TYPE,
                        DUName = item.DU_NAME,
                        ProjectId = item.PROJ_ID,
                        ProjectName = item.PROJ_NAME,
                        ContactName = item.FST_NAME + " " + item.LAST_NAME,
                        EMAIL_ADDR = item.EMAIL_ADDR,
                        PHONE_NO = item.PHONE_NO,
                        BU_Flag = item.BU_FLG
                    };
                    list.Add(model);
                }
                if (Request.IsAjaxRequest())
                {
                    return Json(list, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return View("GetAllBU", list);
                }
            }
            return RedirectToAction("Login2", "Home");
        }

        [HttpPost]
        public ActionResult CreateBusinessUnit(BUViewModel bUViewModel)
        {
            if (Session["Admin"] != null)
            {
                try
                {
                    var session = Session["LogedUser"].ToString();

                    M_PARTY m_PARTY = new M_PARTY();

                    //for alphanumeric PARTY_TYPE_CD
                    var checks = db.M_PARTY.Where(x => x.PARTY_TYPE_CD.Contains("BU")).ToList();
                    m_PARTY.PARTY_TYPE_CD = checks.Max(x => x.PARTY_TYPE_CD);

                    if (m_PARTY.PARTY_TYPE_CD == "0" || m_PARTY.PARTY_TYPE_CD == null)
                    {
                        m_PARTY.PARTY_TYPE_CD = "1-1BU";
                    }
                    else
                    {
                        StringBuilder sb1 = new StringBuilder();
                        var res1 = Regex.Split(m_PARTY.PARTY_TYPE_CD, @"BBU");
                        var chng1 = res1[0].ToString().Split('-');
                        var inc1 = ((Convert.ToInt32(chng1[1])) + 1).ToString();

                        sb1.Append("1-" + inc1 + "BBU");
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
                    m_PARTY.LAST_UPD_DT = null;
                    m_PARTY.ACTIVE_FLG = "1";
                    db.M_PARTY.Add(m_PARTY);

                    var checks2 = db.M_BU.Where(x => x.BU_ID.Contains("BBU")).ToList();
                    bUViewModel.BUId = checks2.Max(x => x.BU_ID);
                    //for alphanumeric user id   
                    var res = Regex.Split(bUViewModel.BUId, @"BBU");

                    if (bUViewModel.BUId == "0" || bUViewModel.BUId == null)
                    {
                        bUViewModel.BUId = "1-1BBU";
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        var chng = res[0].ToString().Split('-');
                        var inc = (Convert.ToInt32(chng[1]) + 1).ToString();
                        sb.Append("2-" + inc + "BBU");
                        bUViewModel.BUId = sb.ToString();
                        //For RowId
                        StringBuilder sbrowid = new StringBuilder();
                        var chng1 = res[0].ToString().Split('-');
                        var inc1 = (Convert.ToInt32(chng1[1]) + 1).ToString();
                        sbrowid.Append("2-" + inc1 + "BBU");
                        bUViewModel.ROW_ID = sbrowid.ToString();
                        //For PAR_Row_ID
                        StringBuilder sbparrowid = new StringBuilder();
                        var chng2 = res[0].ToString().Split('-');
                        var inc2 = (Convert.ToInt32(chng2[1]) + 1).ToString();
                        sbparrowid.Append("2-" + inc2 + "BBU");
                        bUViewModel.PAR_ROW_ID = sbparrowid.ToString();
                        // for PAR_Bu_Id
                        StringBuilder sbparbuid = new StringBuilder();
                        var chng3 = res[0].ToString().Split('-');
                        var inc3 = (Convert.ToInt32(chng3[1]) + 1).ToString();
                        sbparbuid.Append("2-" + inc3 + "BBU");
                        bUViewModel.PAR_BU_ID = sbparbuid.ToString();
                    }

                    //Start BU Details
                    AddBUDetails(bUViewModel, session);

                    //Contact Details 
                    var contactDetails = GetContactDetails(bUViewModel.PERSON_UID);


                    //create personId
                    var resC = Regex.Split(bUViewModel.BUId, @"BBU");
                    StringBuilder sbContactId = new StringBuilder();
                    var chng0 = resC[0].ToString().Split('-');
                    var inc0 = (Convert.ToInt32(chng0[1]) + 1).ToString();
                    sbContactId.Append("2-" + inc0 + "CONTACT");

                    //Create rowId
                    StringBuilder sbRowId = new StringBuilder();
                    var chng01 = resC[0].ToString().Split('-');
                    Random rnd = new Random();
                    char randomChar = (char)rnd.Next('A', 'Z');
                    var inc01 = (Convert.ToInt32(chng01[1]) + 1).ToString();
                    sbRowId.Append("2-" + inc01 + randomChar + "CONTACT");

                    //Add contact details
                    AddContactDetails(contactDetails, sbContactId.ToString(), sbRowId.ToString(), session, bUViewModel.BUId);
                    return Json(new { status = true, message = "Record added successfully." }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new { status = false, message = "Something went wrong." }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("Login2", "Home");
            }
        }



        private void AddContactDetails(M_CONTACT contactDetails, string personId, string rowId, string createdBy, string buId)
        {
            try
            {           
                    M_CONTACT m_CONTACT = new M_CONTACT();
                    m_CONTACT.PERSON_UID = personId;
                    m_CONTACT.ACTIVE_FLG = contactDetails.ACTIVE_FLG;
                    m_CONTACT.EMAIL_ADDR = contactDetails.EMAIL_ADDR;
                    m_CONTACT.EMP_FLG = contactDetails.EMP_FLG;
                    m_CONTACT.EMP_ID = contactDetails.EMP_ID;
                    m_CONTACT.FST_NAME = contactDetails.FST_NAME;
                    m_CONTACT.LAST_NAME = contactDetails.LAST_NAME;
                    m_CONTACT.LAST_UPD_BY = null;
                    m_CONTACT.LAST_UPD_DT = null;
                    m_CONTACT.CREATED_BY = createdBy;
                    m_CONTACT.CREATED_DT = DateTime.UtcNow;
                    m_CONTACT.PAR_ROW_ID = contactDetails.PAR_ROW_ID;
                    m_CONTACT.PHONE_NO = contactDetails.PHONE_NO;
                    m_CONTACT.BU_ID = buId;
                    m_CONTACT.ROW_ID = rowId;
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
                TempData["message"]  = "Wrong";
            }
        }

        private void AddBUDetails(BUViewModel bUViewModel, string createdBy)
        {
            try
            {
                    M_BU m_BU = new M_BU();
                    m_BU.ROW_ID = bUViewModel.ROW_ID;
                    m_BU.CREATED_BY = createdBy;
                    m_BU.CREATED_DT = System.DateTime.Now;
                    m_BU.LAST_UPD_BY = null;
                    m_BU.LAST_UPD_DT = null;
                    m_BU.BU_ID = bUViewModel.BUId;
                    m_BU.BU_NAME = bUViewModel.BUName;
                    m_BU.BU_TYPE = bUViewModel.BUType;
                    m_BU.DU_NAME = bUViewModel.DUName;
                    m_BU.PROJ_ID = bUViewModel.ProjectId;
                    m_BU.PROJ_NAME = bUViewModel.ProjectName;
                    m_BU.BU_FLG = "1";
                    m_BU.PAR_BU_ID = bUViewModel.PAR_BU_ID;
                    m_BU.PAR_ROW_ID = bUViewModel.PAR_ROW_ID;
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
                TempData["message"] = "Wrong";
            }
        }


        [HttpPost]
        public ActionResult EditBusinessUnit(BUViewModel bUViewModel)
        {
            if (Session["Admin"] != null)
            {
                var sess = Session["Admin"].ToString();
                if (bUViewModel.BUId != null)
                {
                    bUViewModel.BUId = bUViewModel.BUId.Trim();
                    var buId = db.M_BU.Where(x => x.BU_ID == bUViewModel.BUId).FirstOrDefault();
                    if (buId != null)
                    {
                        buId.BU_NAME = bUViewModel.BUName.Trim();
                        buId.BU_TYPE = bUViewModel.BUType.Trim();
                        buId.DU_NAME = bUViewModel.DUName.Trim();
                        buId.PROJ_ID = bUViewModel.ProjectId;
                        buId.PROJ_NAME = bUViewModel.ProjectName;
                        buId.LAST_UPD_DT = System.DateTime.Now;
                        buId.LAST_UPD_BY = sess;
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        return RedirectToAction("Index");
                    }
                }
            }
            return RedirectToAction("Login2", "Home");
        }

        [HttpPost]
        public ActionResult DeleteBusinessUnit(BUViewModel id)
        {
            if (Session["Admin"] != null)
            {

                if (id.BUId != null)
                {
                    id.BUId = id.BUId.Trim();
                    M_BU bu = db.M_BU.Find(id.BUId);
                    bu.BU_FLG = "0";
                    db.SaveChanges();
                }
                return RedirectToAction("GetAllBU");
            }
            return RedirectToAction("Login2", "Home");
        }

        public M_CONTACT GetContactDetails(string contactId)
        {
            try
            {
                var contactDetails = db.M_CONTACT.FirstOrDefault(m => m.PERSON_UID == contactId);
                return contactDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public JsonResult PopulateContactDetails()
        {
            try
            {
                var list = db.M_CONTACT.ToList().Select(m => new
                {
                    contactId = m.PERSON_UID,
                    contactDesc = m.FST_NAME + " " + m.LAST_NAME,

                }).ToList();
                ViewBag.ContactDetails = list;
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult GetContactDetailsById(string contactId)
        {
            try
            {
                if (!string.IsNullOrEmpty(contactId))
                {
                    var contact = GetContactDetails(contactId);
                    var details = new
                    {
                        contact.EMAIL_ADDR,
                        contact.PHONE_NO
                    };
                    return Json(details, JsonRequestBehavior.AllowGet);
                }
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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
        [HttpPost]
        public ActionResult ActivateDeactivateUserBU(string id, string isActive)
        {
            try
            {
                if (isActive == "true")
                {
                    isActive = "1";
                }
                else
                {
                    isActive = "0";
                }
                var m_BUnit = db.M_BU.Where(m => m.BU_ID == id).FirstOrDefault();
                if (m_BUnit != null)
                {
                    m_BUnit.BU_FLG = isActive;
                    m_BUnit.LAST_UPD_BY = Session["LogedUser"].ToString();
                    m_BUnit.LAST_UPD_DT = DateTime.Now;
                    db.SaveChanges();
                    return RedirectToAction("GetAllBU");
                }
                return RedirectToAction("Login2", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login2", "Home");
            }
        }
    }
}