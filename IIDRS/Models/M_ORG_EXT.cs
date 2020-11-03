namespace IIDRS
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class M_ORG_EXT
    {
        [Key]
        [StringLength(50)]
        [DisplayName("Row Id")]
        public string ROW_ID { get; set; }

        [StringLength(50)]
        [DisplayName("Brand Name")]
        public string NAME { get; set; }

        [StringLength(50)]
        [DisplayName("Location")]

        public string LOC { get; set; }

        [StringLength(50)]
        [DisplayName("BU Id")]

        public string BU_ID { get; set; }

        [StringLength(50)]
        public string ACCNT_FLG { get; set; }

        [StringLength(50)]
        public string ACTIVE_FLG { get; set; }

        [StringLength(50)]
        public string PAR_ROW_ID { get; set; }

        public DateTime? CUST_END_DT { get; set; }

        public DateTime? CUST_SINCE_DT { get; set; }

        [StringLength(50)]
        public string PAR_BU_ID { get; set; }

        [StringLength(50)]
        public string PARTNER_FLG { get; set; }

        [StringLength(50)]
        public string PAR_DIVN_ID { get; set; }

        [StringLength(50)]
        public string PR_ADDR_ID { get; set; }

        [StringLength(50)]
        public string PR_ADDR_PER_ID { get; set; }

        [StringLength(50)]
        public string PR_BL_ADDR_ID { get; set; }

        [StringLength(50)]
        public string PR_BL_PER_ID { get; set; }

        [StringLength(50)]
        public string PR_CON_ID { get; set; }

        [StringLength(50)]
        public string PR_POSTN_ID { get; set; }

        [StringLength(50)]
        public string SURVEY_ID { get; set; }

        [StringLength(50)]
        [DisplayName("Rating")]

        public string RATING { get; set; }

        [StringLength(50)]
        public string ZIPCODE { get; set; }

        public DateTime? CREATED_DT { get; set; }

        [StringLength(50)]
        public string CREATED_BY { get; set; }

        public DateTime? LAST_UPD_DT { get; set; }

        [StringLength(50)]
        public string LAST_UPD_BY { get; set; }

        public virtual M_ADDR_PER M_ADDR_PER { get; set; }

        public virtual M_BU M_BU { get; set; }

        public virtual M_CUST_SURVEY M_CUST_SURVEY { get; set; }

        public virtual M_POSTN M_POSTN { get; set; }

        public virtual M_PARTY M_PARTY { get; set; }

        public virtual M_USER M_USER { get; set; }

        public virtual M_USER M_USER1 { get; set; }

        public virtual M_ZIPCODE M_ZIPCODE { get; set; }
    }
}
