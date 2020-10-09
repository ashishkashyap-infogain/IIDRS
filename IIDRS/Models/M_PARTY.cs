namespace IIDRS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M_PARTY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public M_PARTY()
        {
            M_CONTACT = new HashSet<M_CONTACT>();
            M_CUST_SURVEY = new HashSet<M_CUST_SURVEY>();
            M_ORG_EXT = new HashSet<M_ORG_EXT>();
            M_POSTN = new HashSet<M_POSTN>();
            M_USER = new HashSet<M_USER>();
            M_ZIPCODE = new HashSet<M_ZIPCODE>();
        }

        //[Required]
        [StringLength(50)]
        public string PARTY_UID { get; set; }

        [Key]
        [StringLength(50)]
        public string PARTY_TYPE_CD { get; set; }

        [StringLength(50)]
        public string TRANS_FLG { get; set; }

        [Required]
        [StringLength(50)]
        public string ACTIVE_FLG { get; set; }

        public DateTime? CREATED_DT { get; set; }

        public DateTime? LAST_UPD_DT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_CONTACT> M_CONTACT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_CUST_SURVEY> M_CUST_SURVEY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_ORG_EXT> M_ORG_EXT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_POSTN> M_POSTN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_USER> M_USER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_ZIPCODE> M_ZIPCODE { get; set; }
    }
}
