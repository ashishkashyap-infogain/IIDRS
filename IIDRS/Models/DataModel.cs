namespace IIDRS
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<M_ADDR_PER> M_ADDR_PER { get; set; }
        public virtual DbSet<M_BU> M_BU { get; set; }
        public virtual DbSet<M_CONTACT> M_CONTACT { get; set; }
        public virtual DbSet<M_CUST_SURVEY> M_CUST_SURVEY { get; set; }
        public virtual DbSet<M_ORG_EXT> M_ORG_EXT { get; set; }
        public virtual DbSet<M_PARTY> M_PARTY { get; set; }
        public virtual DbSet<M_POSTN> M_POSTN { get; set; }
        public virtual DbSet<M_USER> M_USER { get; set; }
        public virtual DbSet<M_ZIPCODE> M_ZIPCODE { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<M_ADDR_PER>()
                .Property(e => e.ROW_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_ADDR_PER>()
                .Property(e => e.PERSON_UID)
                .IsUnicode(false);

            modelBuilder.Entity<M_ADDR_PER>()
                .Property(e => e.ADDR)
                .IsUnicode(false);

            modelBuilder.Entity<M_ADDR_PER>()
                .Property(e => e.ADDR_LINE_2)
                .IsUnicode(false);

            modelBuilder.Entity<M_ADDR_PER>()
                .Property(e => e.ADDR_LINE_3)
                .IsUnicode(false);

            modelBuilder.Entity<M_ADDR_PER>()
                .Property(e => e.ADDR_FLG)
                .IsUnicode(false);

            modelBuilder.Entity<M_ADDR_PER>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<M_ADDR_PER>()
                .Property(e => e.COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<M_ADDR_PER>()
                .Property(e => e.STATE)
                .IsUnicode(false);

            modelBuilder.Entity<M_ADDR_PER>()
                .Property(e => e.ZIPCODE)
                .IsUnicode(false);

            modelBuilder.Entity<M_ADDR_PER>()
                .Property(e => e.COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<M_ADDR_PER>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<M_ADDR_PER>()
                .Property(e => e.LAST_UPD_DT)
                .IsUnicode(false);

            modelBuilder.Entity<M_ADDR_PER>()
                .Property(e => e.LAST_UPD_BY)
                .IsUnicode(false);

            modelBuilder.Entity<M_ADDR_PER>()
                .HasMany(e => e.M_ORG_EXT)
                .WithOptional(e => e.M_ADDR_PER)
                .HasForeignKey(e => e.PR_ADDR_ID);

            modelBuilder.Entity<M_BU>()
                .Property(e => e.ROW_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_BU>()
                .Property(e => e.BU_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_BU>()
                .Property(e => e.PAR_BU_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_BU>()
                .Property(e => e.BU_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<M_BU>()
                .Property(e => e.BU_FLG)
                .IsUnicode(false);

            modelBuilder.Entity<M_BU>()
                .Property(e => e.BU_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<M_BU>()
                .Property(e => e.PAR_ROW_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_BU>()
                .Property(e => e.DU_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<M_BU>()
                .Property(e => e.PROJ_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_BU>()
                .Property(e => e.PROJ_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<M_BU>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<M_BU>()
                .Property(e => e.LAST_UPD_BY)
                .IsUnicode(false);

            modelBuilder.Entity<M_BU>()
                .HasMany(e => e.M_CONTACT)
                .WithRequired(e => e.M_BU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<M_BU>()
                .HasMany(e => e.M_ORG_EXT)
                .WithOptional(e => e.M_BU)
                .HasForeignKey(e => e.PAR_BU_ID);

            modelBuilder.Entity<M_BU>()
                .HasMany(e => e.M_POSTN)
                .WithRequired(e => e.M_BU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<M_CONTACT>()
                .Property(e => e.ROW_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_CONTACT>()
                .Property(e => e.PERSON_UID)
                .IsUnicode(false);

            modelBuilder.Entity<M_CONTACT>()
                .Property(e => e.BU_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_CONTACT>()
                .Property(e => e.ACTIVE_FLG)
                .IsUnicode(false);

            modelBuilder.Entity<M_CONTACT>()
                .Property(e => e.PAR_ROW_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_CONTACT>()
                .Property(e => e.EMP_FLG)
                .IsUnicode(false);

            modelBuilder.Entity<M_CONTACT>()
                .Property(e => e.FST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<M_CONTACT>()
                .Property(e => e.LAST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<M_CONTACT>()
                .Property(e => e.EMAIL_ADDR)
                .IsUnicode(false);

            modelBuilder.Entity<M_CONTACT>()
                .Property(e => e.EMP_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_CONTACT>()
                .Property(e => e.PHONE_NO)
                .IsUnicode(false);

            modelBuilder.Entity<M_CONTACT>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<M_CONTACT>()
                .Property(e => e.LAST_UPD_BY)
                .IsUnicode(false);

            modelBuilder.Entity<M_CUST_SURVEY>()
                .Property(e => e.ROW_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_CUST_SURVEY>()
                .Property(e => e.SURVEY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_CUST_SURVEY>()
                .Property(e => e.PAR_ROW_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_CUST_SURVEY>()
                .Property(e => e.CUST_SURVEY_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<M_CUST_SURVEY>()
                .Property(e => e.SURVEY_QUESTION_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<M_CUST_SURVEY>()
                .Property(e => e.SURVEY_QUESTION_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<M_CUST_SURVEY>()
                .Property(e => e.SURVEY_FLG)
                .IsUnicode(false);

            modelBuilder.Entity<M_CUST_SURVEY>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<M_CUST_SURVEY>()
                .Property(e => e.LAST_UPD_BY)
                .IsUnicode(false);

            modelBuilder.Entity<M_ORG_EXT>()
                .Property(e => e.ROW_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_ORG_EXT>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<M_ORG_EXT>()
                .Property(e => e.LOC)
                .IsUnicode(false);

            modelBuilder.Entity<M_ORG_EXT>()
                .Property(e => e.BU_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_ORG_EXT>()
                .Property(e => e.ACCNT_FLG)
                .IsUnicode(false);

            modelBuilder.Entity<M_ORG_EXT>()
                .Property(e => e.ACTIVE_FLG)
                .IsUnicode(false);

            modelBuilder.Entity<M_ORG_EXT>()
                .Property(e => e.PAR_ROW_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_ORG_EXT>()
                .Property(e => e.PAR_BU_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_ORG_EXT>()
                .Property(e => e.PARTNER_FLG)
                .IsUnicode(false);

            modelBuilder.Entity<M_ORG_EXT>()
                .Property(e => e.PAR_DIVN_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_ORG_EXT>()
                .Property(e => e.PR_ADDR_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_ORG_EXT>()
                .Property(e => e.PR_ADDR_PER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_ORG_EXT>()
                .Property(e => e.PR_BL_ADDR_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_ORG_EXT>()
                .Property(e => e.PR_BL_PER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_ORG_EXT>()
                .Property(e => e.PR_CON_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_ORG_EXT>()
                .Property(e => e.PR_POSTN_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_ORG_EXT>()
                .Property(e => e.SURVEY_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_ORG_EXT>()
                .Property(e => e.RATING)
                .IsUnicode(false);

            modelBuilder.Entity<M_ORG_EXT>()
                .Property(e => e.ZIPCODE)
                .IsUnicode(false);

            modelBuilder.Entity<M_ORG_EXT>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<M_ORG_EXT>()
                .Property(e => e.LAST_UPD_BY)
                .IsUnicode(false);

            modelBuilder.Entity<M_PARTY>()
                .Property(e => e.PARTY_UID)
                .IsUnicode(false);

            modelBuilder.Entity<M_PARTY>()
                .Property(e => e.PARTY_TYPE_CD)
                .IsUnicode(false);

            modelBuilder.Entity<M_PARTY>()
                .Property(e => e.TRANS_FLG)
                .IsUnicode(false);

            modelBuilder.Entity<M_PARTY>()
                .Property(e => e.ACTIVE_FLG)
                .IsUnicode(false);

            modelBuilder.Entity<M_PARTY>()
                .HasMany(e => e.M_CONTACT)
                .WithRequired(e => e.M_PARTY)
                .HasForeignKey(e => e.PAR_ROW_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<M_PARTY>()
                .HasMany(e => e.M_CUST_SURVEY)
                .WithRequired(e => e.M_PARTY)
                .HasForeignKey(e => e.PAR_ROW_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<M_PARTY>()
                .HasMany(e => e.M_ORG_EXT)
                .WithRequired(e => e.M_PARTY)
                .HasForeignKey(e => e.PAR_ROW_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<M_PARTY>()
                .HasMany(e => e.M_POSTN)
                .WithRequired(e => e.M_PARTY)
                .HasForeignKey(e => e.ROW_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<M_PARTY>()
                .HasMany(e => e.M_USER)
                .WithRequired(e => e.M_PARTY)
                .HasForeignKey(e => e.PAR_ROW_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<M_PARTY>()
                .HasMany(e => e.M_ZIPCODE)
                .WithRequired(e => e.M_PARTY)
                .HasForeignKey(e => e.PAR_ROW_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<M_POSTN>()
                .Property(e => e.ROW_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_POSTN>()
                .Property(e => e.BU_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_POSTN>()
                .Property(e => e.POSTN_TYPE_CD)
                .IsUnicode(false);

            modelBuilder.Entity<M_POSTN>()
                .Property(e => e.POSTN_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<M_POSTN>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<M_POSTN>()
                .Property(e => e.LAST_UPD_BY)
                .IsUnicode(false);

            modelBuilder.Entity<M_POSTN>()
                .HasMany(e => e.M_ORG_EXT)
                .WithOptional(e => e.M_POSTN)
                .HasForeignKey(e => e.PR_POSTN_ID);

            modelBuilder.Entity<M_USER>()
                .Property(e => e.USER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_USER>()
                .Property(e => e.LOGIN)
                .IsUnicode(false);

            modelBuilder.Entity<M_USER>()
                .Property(e => e.LOGIN_DOMAIN)
                .IsUnicode(false);

            modelBuilder.Entity<M_USER>()
                .Property(e => e.PAR_ROW_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_USER>()
                .Property(e => e.USER_FLG)
                .IsUnicode(false);

            modelBuilder.Entity<M_USER>()
                .Property(e => e.CHALLENGE_ANSWER)
                .IsUnicode(false);

            modelBuilder.Entity<M_USER>()
                .Property(e => e.CHALLENGE_QUESTION)
                .IsUnicode(false);

            modelBuilder.Entity<M_USER>()
                .Property(e => e.CTI_ACD_USERID)
                .IsUnicode(false);

            modelBuilder.Entity<M_USER>()
                .Property(e => e.CTI_PWD)
                .IsUnicode(false);

            modelBuilder.Entity<M_USER>()
                .Property(e => e.EXCHNG_PROF_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<M_USER>()
                .Property(e => e.EXCHNG_PROF_PWD)
                .IsUnicode(false);

            modelBuilder.Entity<M_USER>()
                .Property(e => e.EXCHNG_STOREID)
                .IsUnicode(false);

            modelBuilder.Entity<M_USER>()
                .Property(e => e.EXCHNG_SYNC_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<M_USER>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<M_USER>()
                .Property(e => e.PW_LAST_UPD)
                .IsUnicode(false);

            modelBuilder.Entity<M_USER>()
                .Property(e => e.RPT_SRVR_PWD)
                .IsUnicode(false);

            modelBuilder.Entity<M_USER>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<M_USER>()
                .Property(e => e.LAST_UPD_BY)
                .IsUnicode(false);

            modelBuilder.Entity<M_USER>()
                .HasMany(e => e.M_ADDR_PER)
                .WithOptional(e => e.M_USER)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<M_USER>()
                .HasMany(e => e.M_ADDR_PER1)
                .WithOptional(e => e.M_USER1)
                .HasForeignKey(e => e.LAST_UPD_BY);

            modelBuilder.Entity<M_USER>()
                .HasMany(e => e.M_CONTACT)
                .WithOptional(e => e.M_USER)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<M_USER>()
                .HasMany(e => e.M_CONTACT1)
                .WithOptional(e => e.M_USER1)
                .HasForeignKey(e => e.LAST_UPD_BY);

            modelBuilder.Entity<M_USER>()
                .HasMany(e => e.M_CUST_SURVEY)
                .WithOptional(e => e.M_USER)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<M_USER>()
                .HasMany(e => e.M_CUST_SURVEY1)
                .WithOptional(e => e.M_USER1)
                .HasForeignKey(e => e.LAST_UPD_BY);

            modelBuilder.Entity<M_USER>()
                .HasMany(e => e.M_ORG_EXT)
                .WithOptional(e => e.M_USER)
                .HasForeignKey(e => e.LAST_UPD_BY);

            modelBuilder.Entity<M_USER>()
                .HasMany(e => e.M_ORG_EXT1)
                .WithOptional(e => e.M_USER1)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<M_USER>()
                .HasMany(e => e.M_POSTN)
                .WithOptional(e => e.M_USER)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<M_USER>()
                .HasMany(e => e.M_POSTN1)
                .WithOptional(e => e.M_USER1)
                .HasForeignKey(e => e.LAST_UPD_BY);

            modelBuilder.Entity<M_USER>()
                .HasMany(e => e.M_ZIPCODE)
                .WithOptional(e => e.M_USER)
                .HasForeignKey(e => e.CREATED_BY);

            modelBuilder.Entity<M_USER>()
                .HasMany(e => e.M_ZIPCODE1)
                .WithOptional(e => e.M_USER1)
                .HasForeignKey(e => e.LAST_UPD_BY);

            modelBuilder.Entity<M_ZIPCODE>()
                .Property(e => e.ROW_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_ZIPCODE>()
                .Property(e => e.PAR_ROW_ID)
                .IsUnicode(false);

            modelBuilder.Entity<M_ZIPCODE>()
                .Property(e => e.ZIPCODE)
                .IsUnicode(false);

            modelBuilder.Entity<M_ZIPCODE>()
                .Property(e => e.COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<M_ZIPCODE>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<M_ZIPCODE>()
                .Property(e => e.CONTINENT)
                .IsUnicode(false);

            modelBuilder.Entity<M_ZIPCODE>()
                .Property(e => e.COUNTY)
                .IsUnicode(false);

            modelBuilder.Entity<M_ZIPCODE>()
                .Property(e => e.LATITUDE)
                .IsUnicode(false);

            modelBuilder.Entity<M_ZIPCODE>()
                .Property(e => e.LONGITUDE)
                .IsUnicode(false);

            modelBuilder.Entity<M_ZIPCODE>()
                .Property(e => e.STATE_PROV)
                .IsUnicode(false);

            modelBuilder.Entity<M_ZIPCODE>()
                .Property(e => e.STREET_ABBREV)
                .IsUnicode(false);

            modelBuilder.Entity<M_ZIPCODE>()
                .Property(e => e.STREET_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<M_ZIPCODE>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<M_ZIPCODE>()
                .Property(e => e.LAST_UPD_BY)
                .IsUnicode(false);
        }
    }
}
