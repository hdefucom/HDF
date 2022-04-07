using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ConsoleApp2.Models;

namespace ConsoleApp2.Db
{
    public partial class GYYTContext : DbContext
    {
        public GYYTContext()
        {
        }

        public GYYTContext(DbContextOptions<GYYTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<D_TEST> D_TESTs { get; set; }
        public virtual DbSet<GYYT_CS_FUNCIOTN> GYYT_CS_FUNCIOTNs { get; set; }
        public virtual DbSet<GYYT_MACHINE> GYYT_MACHINEs { get; set; }
        public virtual DbSet<GYYT_MACHINE_EQUIP> GYYT_MACHINE_EQUIPs { get; set; }
        public virtual DbSet<GYYT_MACHINE_FUN> GYYT_MACHINE_FUNs { get; set; }
        public virtual DbSet<GYYT_STATUS_RECORD> GYYT_STATUS_RECORDs { get; set; }
        public virtual DbSet<SYS_DICTIONARY> SYS_DICTIONARies { get; set; }
        public virtual DbSet<SYS_DICTIONARY_ITEM> SYS_DICTIONARY_ITEMs { get; set; }
        public virtual DbSet<SYS_HOSPITAL> SYS_HOSPITALs { get; set; }
        public virtual DbSet<SYS_LOGINFO> SYS_LOGINFOs { get; set; }
        public virtual DbSet<SYS_MENU> SYS_MENUs { get; set; }
        public virtual DbSet<SYS_PARAMETER> SYS_PARAMETERs { get; set; }
        public virtual DbSet<SYS_ROLE> SYS_ROLEs { get; set; }
        public virtual DbSet<SYS_ROLE_MENU> SYS_ROLE_MENUs { get; set; }
        public virtual DbSet<SYS_ROLE_USER> SYS_ROLE_USERs { get; set; }
        public virtual DbSet<SYS_USER> SYS_USERs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.0.46)(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=ORCL))); User Id=gyyt3dba;Password=sa;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("GYYT3DBA")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<D_TEST>(entity =>
            {
                entity.HasKey(e => e.Q)
                    .HasName("PK_Q");
            });

            modelBuilder.Entity<GYYT_CS_FUNCIOTN>(entity =>
            {
                entity.HasKey(e => e.CS_FUNCIOTN_ID)
                    .HasName("PK_CS_FUNCIOTN_ID");
            });

            modelBuilder.Entity<GYYT_MACHINE>(entity =>
            {
                entity.HasKey(e => e.MACHINE_ID)
                    .HasName("PK_MACHINE_ID");

                entity.Property(e => e.IS_ENABLE).HasDefaultValueSql("0\n");
            });

            modelBuilder.Entity<GYYT_MACHINE_EQUIP>(entity =>
            {
                entity.HasKey(e => e.MACHINE_EQUIP_ID)
                    .HasName("PK_MACHINE_EQUIP_ID");

                entity.Property(e => e.IS_ENABLE).HasDefaultValueSql("0\n");
            });

            modelBuilder.Entity<GYYT_MACHINE_FUN>(entity =>
            {
                entity.HasKey(e => e.MACHINE_FUN_ID)
                    .HasName("PK_MACHINE_FUN_ID");
            });

            modelBuilder.Entity<GYYT_STATUS_RECORD>(entity =>
            {
                entity.HasKey(e => e.STATUS_RECORD_ID)
                    .HasName("PK_STATUS_RECORD_ID");
            });

            modelBuilder.Entity<SYS_DICTIONARY>(entity =>
            {
                entity.Property(e => e.VALID).HasDefaultValueSql("1\n");
            });

            modelBuilder.Entity<SYS_DICTIONARY_ITEM>(entity =>
            {
                entity.Property(e => e.VALID).HasDefaultValueSql("1");
            });

            modelBuilder.Entity<SYS_HOSPITAL>(entity =>
            {
                entity.HasKey(e => e.HOSPITAL_ID)
                    .HasName("PK_HOSPITAL_ID");
            });

            modelBuilder.Entity<SYS_MENU>(entity =>
            {
                entity.Property(e => e.IS_HIDDEN).HasDefaultValueSql("1");

                entity.Property(e => e.KEEPALIVE).HasDefaultValueSql("0\n");

                entity.Property(e => e.VALID).HasDefaultValueSql("1");
            });

            modelBuilder.Entity<SYS_PARAMETER>(entity =>
            {
                entity.HasKey(e => e.PARAMETER_ID)
                    .HasName("SYS_C0015623");

                entity.Property(e => e.VALID).HasDefaultValueSql("1");
            });

            modelBuilder.Entity<SYS_ROLE>(entity =>
            {
                entity.Property(e => e.VALID).HasDefaultValueSql("1\n");
            });

            modelBuilder.Entity<SYS_USER>(entity =>
            {
                entity.Property(e => e.VALID).HasDefaultValueSql("1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
