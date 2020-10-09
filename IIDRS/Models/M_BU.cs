namespace IIDRS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M_BU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public M_BU()
        {
            M_CONTACT = new HashSet<M_CONTACT>();
            M_ORG_EXT = new HashSet<M_ORG_EXT>();
            M_POSTN = new HashSet<M_POSTN>();
        }

        [Required]
        [StringLength(50)]
        public string ROW_ID { get; set; }

        [Key]
        [StringLength(50)]
        public string BU_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string PAR_BU_ID { get; set; }

        [StringLength(50)]
        public string BU_NAME { get; set; }

        [StringLength(50)]
        public string BU_FLG { get; set; }

        [StringLength(50)]
        public string BU_TYPE { get; set; }

        [Required]
        [StringLength(50)]
        public string PAR_ROW_ID { get; set; }

        [StringLength(50)]
        public string DU_NAME { get; set; }

        [StringLength(50)]
        public string PROJ_ID { get; set; }

        [StringLength(50)]
        public string PROJ_NAME { get; set; }

        public DateTime? CREATED_DT { get; set; }

        [StringLength(50)]
        public string CREATED_BY { get; set; }

        public DateTime? LAST_UPD_DT { get; set; }

        [StringLength(50)]
        public string LAST_UPD_BY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_CONTACT> M_CONTACT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_ORG_EXT> M_ORG_EXT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_POSTN> M_POSTN { get; set; }
    }
}
