using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IIDRS.ViewModel
{
    public class ContactViewModel
    {
        [DisplayName("ID")]
        public string EMP_ID { get; set; }

        [DisplayName("First Name")]
        public string FST_NAME { get; set; }
        [DisplayName("Last Name")]
        public string LAST_NAME { get; set; }
        [DisplayName("Email")]
        public string EMAIL_ADDR { get; set; }
        [DisplayName("Phone no.")]
        public string PHONE_NO { get; set; }
        [DisplayName("BU ID")]
        public string BU_ID { get; set; }
        [DisplayName("BU ")]
        public string BU_NAME { get; set; }
        [DisplayName("DU")]
        public string DU_NAME { get; set; }
        [DisplayName("Project")]
        public string PROJ_NAME { get; set; }
        [DisplayName("Updated date")]
        public string LAST_UPD_DT { get; set; }
        [DisplayName("Active")]
        public string ACTIVE_FLG { get; set; }

        public string PERSON_UID { get; set; }
        public string PAR_ROW_ID { get; set; }
        public string EMP_FLG { get; set; }
        public string ROW_ID { get; set; }

        public string BU_TYPE { get; set; }

        public string PROJ_ID { get; set; }

        public string PAR_BU_ID { get; set; }

    }
}

              