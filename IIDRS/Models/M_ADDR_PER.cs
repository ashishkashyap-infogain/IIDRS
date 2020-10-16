namespace IIDRS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M_ADDR_PER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public M_ADDR_PER()
        {
            M_ORG_EXT = new HashSet<M_ORG_EXT>();
        }

        [Key]
        [StringLength(50)]
        [DisplayName("Row Id")]
        public string ROW_ID { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Person UId")]

        public string PERSON_UID { get; set; }

        [StringLength(50)]
        [DisplayName("Address")]

        public string ADDR { get; set; }

        [StringLength(50)]
        [DisplayName("Address Line 2")]

        public string ADDR_LINE_2 { get; set; }

        [StringLength(50)]
        [DisplayName("Address Line 3")]

        public string ADDR_LINE_3 { get; set; }

        [StringLength(50)]

        public string ADDR_FLG { get; set; }

        [StringLength(50)]
        [DisplayName("City")]

        public string CITY { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Country")]

        public string COUNTRY { get; set; }

        [StringLength(50)]
        [DisplayName("State")]

        public string STATE { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Zip Code")]

        public string ZIPCODE { get; set; }

        [StringLength(50)]
        [DisplayName("Comments")]

        public string COMMENTS { get; set; }

        [DisplayName("Created Date")]

        public DateTime? CREATED_DT { get; set; }

        [StringLength(50)]
        [DisplayName("Created By")]

        public string CREATED_BY { get; set; }

        [StringLength(50)]
        [DisplayName("Last Updated Date")]

        public string LAST_UPD_DT { get; set; }

        [StringLength(50)]
        [DisplayName("Last Updated By")]

        public string LAST_UPD_BY { get; set; }

        [DisplayName("M User")]

        public virtual M_USER M_USER { get; set; }

        [DisplayName("M User1")]

        public virtual M_USER M_USER1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_ORG_EXT> M_ORG_EXT { get; set; }
    }
}
