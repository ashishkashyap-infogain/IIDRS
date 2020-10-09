namespace IIDRS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M_CONTACT
    {
        [Required]
        [StringLength(50)]
        public string ROW_ID { get; set; }

        [Key]
        [StringLength(50)]
        public string PERSON_UID { get; set; }

        [Required]
        [StringLength(50)]
        public string BU_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ACTIVE_FLG { get; set; }

        [Required]
        [StringLength(50)]
        public string PAR_ROW_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string EMP_FLG { get; set; }

        [StringLength(50)]
        public string FST_NAME { get; set; }

        [StringLength(50)]
        public string LAST_NAME { get; set; }

        [StringLength(50)]
        public string EMAIL_ADDR { get; set; }

        [StringLength(50)]
        public string EMP_ID { get; set; }

        [StringLength(50)]
        public string PHONE_NO { get; set; }

        public DateTime? CREATED_DT { get; set; }

        [StringLength(50)]
        public string CREATED_BY { get; set; }

        public DateTime? LAST_UPD_DT { get; set; }

        [StringLength(50)]
        public string LAST_UPD_BY { get; set; }

        public virtual M_BU M_BU { get; set; }

        public virtual M_PARTY M_PARTY { get; set; }

        public virtual M_USER M_USER { get; set; }

        public virtual M_USER M_USER1 { get; set; }
    }
}
