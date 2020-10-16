namespace IIDRS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M_CONTACT
    {
        [Required]
        [StringLength(50)]
        [DisplayName("Row Id")]

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
        [DisplayName("First Name")]

        public string FST_NAME { get; set; }

        [StringLength(50)]
        [DisplayName("Last Name")]


        public string LAST_NAME { get; set; }

        [StringLength(50)]
        [DisplayName("Email Address")]

        public string EMAIL_ADDR { get; set; }

        [StringLength(50)]
        [DisplayName("Employee Id")]

        public string EMP_ID { get; set; }

        [StringLength(50)]
        [DisplayName("Phone Number")]

        public string PHONE_NO { get; set; }

        [DisplayName("Created Date")]

        public DateTime? CREATED_DT { get; set; }

        [StringLength(50)]
        [DisplayName("Created By")]

        public string CREATED_BY { get; set; }

        [DisplayName("Last Updated Date")]

        public DateTime? LAST_UPD_DT { get; set; }

        [StringLength(50)]
        public string LAST_UPD_BY { get; set; }

        public virtual M_BU M_BU { get; set; }

        public virtual M_PARTY M_PARTY { get; set; }

        public virtual M_USER M_USER { get; set; }

        public virtual M_USER M_USER1 { get; set; }
    }
}
