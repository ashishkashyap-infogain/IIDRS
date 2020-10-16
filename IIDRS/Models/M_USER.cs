namespace IIDRS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M_USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public M_USER()
        {
            M_ADDR_PER = new HashSet<M_ADDR_PER>();
            M_ADDR_PER1 = new HashSet<M_ADDR_PER>();
            M_CONTACT = new HashSet<M_CONTACT>();
            M_CONTACT1 = new HashSet<M_CONTACT>();
            M_CUST_SURVEY = new HashSet<M_CUST_SURVEY>();
            M_CUST_SURVEY1 = new HashSet<M_CUST_SURVEY>();
            M_ORG_EXT = new HashSet<M_ORG_EXT>();
            M_ORG_EXT1 = new HashSet<M_ORG_EXT>();
            M_POSTN = new HashSet<M_POSTN>();
            M_POSTN1 = new HashSet<M_POSTN>();
            M_ZIPCODE = new HashSet<M_ZIPCODE>();
            M_ZIPCODE1 = new HashSet<M_ZIPCODE>();
        }

        [Key]
        [StringLength(50)]
        [DisplayName("User Id")]

        public string USER_ID { get; set; }

        [StringLength(50)]
        [DisplayName("Log In")]

        public string LOGIN { get; set; }

        [StringLength(50)]
        [DisplayName("Role")]

        public string LOGIN_DOMAIN { get; set; }

        [StringLength(50)]
        public string PAR_ROW_ID { get; set; }

        [StringLength(50)]
        [DisplayName("User Flg")]

        public string USER_FLG { get; set; }

        [StringLength(50)]
        public string CHALLENGE_ANSWER { get; set; }

        [StringLength(50)]
        public string CHALLENGE_QUESTION { get; set; }

        [StringLength(50)]
        public string CTI_ACD_USERID { get; set; }

        [StringLength(50)]
        public string CTI_PWD { get; set; }

        [StringLength(50)]
        public string EXCHNG_PROF_NAME { get; set; }

        [StringLength(50)]
        public string EXCHNG_PROF_PWD { get; set; }

        [StringLength(50)]
        public string EXCHNG_STOREID { get; set; }

        [StringLength(50)]
        public string EXCHNG_SYNC_TYPE { get; set; }

        [StringLength(50)]
        [DisplayName("Password")]

        public string PASSWORD { get; set; }

        [StringLength(50)]
        [DisplayName("Password Last Updated")]

        public string PW_LAST_UPD { get; set; }

        [StringLength(50)]
        public string RPT_SRVR_PWD { get; set; }

        [DisplayName("Created Date")]

        public DateTime? CREATED_DT { get; set; }

        [StringLength(50)]
        [DisplayName("Created By")]

        public string CREATED_BY { get; set; }

        [DisplayName("Last Updated Date")]

        public DateTime? LAST_UPD_DT { get; set; }

        [StringLength(50)]
        [DisplayName("Last Updated By")]

        public string LAST_UPD_BY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_ADDR_PER> M_ADDR_PER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_ADDR_PER> M_ADDR_PER1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_CONTACT> M_CONTACT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_CONTACT> M_CONTACT1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_CUST_SURVEY> M_CUST_SURVEY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_CUST_SURVEY> M_CUST_SURVEY1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_ORG_EXT> M_ORG_EXT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_ORG_EXT> M_ORG_EXT1 { get; set; }

        public virtual M_PARTY M_PARTY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_POSTN> M_POSTN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_POSTN> M_POSTN1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_ZIPCODE> M_ZIPCODE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_ZIPCODE> M_ZIPCODE1 { get; set; }
    }
}
