namespace IIDRS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M_CUST_SURVEY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public M_CUST_SURVEY()
        {
            M_ORG_EXT = new HashSet<M_ORG_EXT>();
        }

        [Required]
        [StringLength(50)]
        public string ROW_ID { get; set; }

        [Key]
        [StringLength(50)]
        public string SURVEY_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string PAR_ROW_ID { get; set; }

        [StringLength(50)]
        public string CUST_SURVEY_NAME { get; set; }

        [StringLength(50)]
        public string SURVEY_QUESTION_NAME { get; set; }

        [StringLength(50)]
        public string SURVEY_QUESTION_DESC { get; set; }

        [StringLength(50)]
        public string SURVEY_FLG { get; set; }

        public DateTime? CREATED_DT { get; set; }

        [StringLength(50)]
        public string CREATED_BY { get; set; }

        public DateTime? LAST_UPD_DT { get; set; }

        [StringLength(50)]
        public string LAST_UPD_BY { get; set; }

        public virtual M_PARTY M_PARTY { get; set; }

        public virtual M_USER M_USER { get; set; }

        public virtual M_USER M_USER1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_ORG_EXT> M_ORG_EXT { get; set; }
    }
}
