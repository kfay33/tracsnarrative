using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TRACSNarrative.Models;

namespace TRACSNarrative.Data
{
    public partial class NarrativeContext : DbContext
    {
        public NarrativeContext()
        {
        }

        public NarrativeContext(DbContextOptions<NarrativeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Narrative> Narrative { get; set; }
        public virtual DbSet<NarrativeText> NarrativeText { get; set; }
        public virtual DbSet<Person> Person { get; set; }


        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TRACS_Narrative;Trusted_Connection=True;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.PerNo)
                    .HasName("PK_PERSON");

                entity.Property(e => e.PerNo)
                    .HasColumnName("PER_NO")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CitznCode)
                    .HasColumnName("CITZN_Code")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.DcsdPerDeathDate)
                    .HasColumnName("DCSD_PER_Death_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DcsdPerDeathFlag)
                    .HasColumnName("DCSD_PER_Death_Flag")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IeIndividualId)
                    .HasColumnName("IE_Individual_ID")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.JobsStatDescShort)
                    .HasColumnName("JOBS_STAT_Desc_Short")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdateBrOffCode)
                    .IsRequired()
                    .HasColumnName("Last_Update_Br_Off_Code")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(substring(db_name(),(5),(8)))");

                entity.Property(e => e.LastUpdateBy)
                    .IsRequired()
                    .HasColumnName("Last_Update_By")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(user_name())");

                entity.Property(e => e.LastUpdateDtTm)
                    .HasColumnName("Last_Update_DtTm")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PerAbawdCode)
                    .HasColumnName("PER_ABAWD_Code")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PerAbawdLastUpdateDtTm)
                    .HasColumnName("PER_ABAWD_Last_Update_DtTm")
                    .HasColumnType("datetime");

                entity.Property(e => e.PerBirthDate)
                    .HasColumnName("PER_Birth_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PerComment)
                    .HasColumnName("PER_Comment")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PerCommentDate)
                    .HasColumnName("PER_Comment_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PerDisAccModCode)
                    .HasColumnName("PER_Dis_Acc_Mod_Code")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.PerDisAccModText)
                    .HasColumnName("PER_Dis_Acc_Mod_Text")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PerDisabilityCode)
                    .HasColumnName("PER_Disability_Code")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.PerEducCode)
                    .HasColumnName("PER_Educ_Code")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.PerEmailAddress)
                    .HasColumnName("PER_Email_Address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PerFirstName)
                    .HasColumnName("PER_First_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PerGoesByName)
                    .HasColumnName("PER_Goes_By_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PerInsertBy)
                    .HasColumnName("PER_Insert_By")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(user_name())");

                entity.Property(e => e.PerInsertDate)
                    .HasColumnName("PER_Insert_Date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PerJasFlag)
                    .HasColumnName("PER_JAS_Flag")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PerLastName)
                    .HasColumnName("PER_Last_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PerMfInSync)
                    .HasColumnName("PER_MF_In_Sync")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PerMi)
                    .HasColumnName("PER_MI")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PerSexCode)
                    .HasColumnName("PER_Sex_Code")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PerSuffixName)
                    .HasColumnName("PER_Suffix_Name")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.PerVeteranFlag)
                    .HasColumnName("PER_Veteran_Flag")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.PnaNmbr)
                    .HasColumnName("PNA_Nmbr")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.RaceCode)
                    .HasColumnName("RACE_Code")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.SsnNmbr)
                    .HasColumnName("SSN_Nmbr")
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<Narrative>(entity =>
            {
                entity.HasKey(e => new { e.BrOffCode, e.NrtvSequenceNmbr })
                    .HasName("PK_NARRATIVE")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.BrOffCode)
                    .HasColumnName("BR_OFF_Code")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.NrtvSequenceNmbr).HasColumnName("NRTV_Sequence_Nmbr");

                entity.Property(e => e.ContTypeCode)
                    .IsRequired()
                    .HasColumnName("CONT_TYPE_Code")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdateBrOffCode)
                    .IsRequired()
                    .HasColumnName("Last_Update_Br_Off_Code")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(substring(db_name(),(5),(8)))");

                entity.Property(e => e.LastUpdateBy)
                    .IsRequired()
                    .HasColumnName("Last_Update_By")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(user_name())");

                entity.Property(e => e.LastUpdateDtTm)
                    .HasColumnName("Last_Update_DtTm")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NrtvEnteredOn)
                    .HasColumnName("NRTV_Entered_On")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.NrtvEntryDate)
                    .HasColumnName("NRTV_Entry_Date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NrtvPendedFlag)
                    .HasColumnName("NRTV_Pended_Flag")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.NrtvScrnsChkdFlag)
                    .HasColumnName("NRTV_Scrns_Chkd_Flag")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.NrtvStatusCode)
                    .HasColumnName("NRTV_Status_Code")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.NrtvStickyNote)
                    .HasColumnName("NRTV_Sticky_Note")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NrtvTimeSpentHours).HasColumnName("NRTV_Time_Spent_Hours");

                entity.Property(e => e.NrtvTimeSpentMinutes).HasColumnName("NRTV_Time_Spent_Minutes");

                entity.Property(e => e.NrtvTypeCode)
                    .IsRequired()
                    .HasColumnName("NRTV_TYPE_Code")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.PerNo)
                    .IsRequired()
                    .HasColumnName("PER_NO")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.TklrAttentionDate)
                    .HasColumnName("TKLR_Attention_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TracsAuthRacfId)
                    .IsRequired()
                    .HasColumnName("TRACS_AUTH_RACF_ID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Narrative)
                    .HasForeignKey(d => new { d.PerNo })
                    .HasConstraintName("FK1Narrative");
            });

            modelBuilder.Entity<NarrativeText>(entity =>
            {
                entity.HasKey(e => new { e.PerNo, e.BrOffCode, e.NrtvSequenceNmbr, e.NrtvTextSeqNmbr });

                entity.ToTable("Narrative_Text");

                entity.Property(e => e.PerNo)
                    .HasColumnName("PER_NO")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.BrOffCode)
                    .HasColumnName("BR_OFF_Code")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.NrtvSequenceNmbr).HasColumnName("NRTV_Sequence_Nmbr");

                entity.Property(e => e.NrtvTextSeqNmbr).HasColumnName("NRTV_TEXT_Seq_Nmbr");

                entity.Property(e => e.LastUpdateBrOffCode)
                    .IsRequired()
                    .HasColumnName("Last_Update_Br_Off_Code")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(substring(db_name(),(5),(8)))");

                entity.Property(e => e.LastUpdateBy)
                    .IsRequired()
                    .HasColumnName("Last_Update_By")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(user_name())");

                entity.Property(e => e.LastUpdateDtTm)
                    .HasColumnName("Last_Update_DtTm")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NrtvTextDetail)
                    .IsRequired()
                    .HasColumnName("NRTV_TEXT_Detail")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Narrative)
                    .WithMany(p => p.NarrativeText)
                    .HasForeignKey(d => new { d.BrOffCode, d.NrtvSequenceNmbr })
                    .HasConstraintName("FK1Narrative_Text");
            });
            

        }
    }
}
