using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IIDRS.ViewModel
{
    public class BUViewModel
    {
        [DisplayName("BU ID")]
        public string BUId { get; set; }
        [DisplayName("BU Name")]
        public string BUName { get; set; }
        [DisplayName("BU Type")]
        public string BUType { get; set; }
        [DisplayName("DU Name")]
        public string DUName { get; set; }
        [DisplayName("Project ID")]
        public string ProjectId { get; set; }
        [DisplayName("Contact Name")]
        public string ContactName { get; set; }
        [DisplayName("Project Name")]
        public string ProjectName { get; set; }
        [DisplayName("Email Address")]
        public string EMAIL_ADDR { get; set; }
        [DisplayName("Phone Number")]
        public string PHONE_NO { get; set; }
        public string ROW_ID { get; set; }
        public string BU_Flag { get; set; }
        public string PAR_ROW_ID { get; set; }
        public string PAR_BU_ID { get; set; }
        public string PERSON_UID { get; set; }
    }
}
