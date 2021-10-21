using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DBCovid.models
{
    public partial class DBCovidContext : DbContext
    {
        public DBCovidContext()
            : base("name=DBCovidContext")
        {
        }

        public virtual DbSet<tbl_benhAn> tbl_benhAn { get; set; }
        public virtual DbSet<tbl_benhNhan> tbl_benhNhan { get; set; }
        public virtual DbSet<tbl_benhVien> tbl_benhVien { get; set; }
        public virtual DbSet<tbl_diaChi> tbl_diaChi { get; set; }
        public virtual DbSet<tbl_huyen> tbl_huyen { get; set; }
        public virtual DbSet<tbl_loaiPhong> tbl_loaiPhong { get; set; }
        public virtual DbSet<tbl_nguoi> tbl_nguoi { get; set; }
        public virtual DbSet<tbl_nguoiDung> tbl_nguoiDung { get; set; }
        public virtual DbSet<tbl_nhanVienYTe> tbl_nhanVienYTe { get; set; }
        public virtual DbSet<tbl_phongBenh> tbl_phongBenh { get; set; }
        public virtual DbSet<tbl_thongTinDieuTri> tbl_thongTinDieuTri { get; set; }
        public virtual DbSet<tbl_thongTinTruyVet> tbl_thongTinTruyVet { get; set; }
        public virtual DbSet<tbl_tinh> tbl_tinh { get; set; }
        public virtual DbSet<tbl_trangThai> tbl_trangThai { get; set; }
        public virtual DbSet<tbl_viTriLamViec> tbl_viTriLamViec { get; set; }
        public virtual DbSet<tbl_xa> tbl_xa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_benhAn>()
                .HasMany(e => e.tbl_thongTinDieuTri)
                .WithRequired(e => e.tbl_benhAn)
                .HasForeignKey(e => e.benhAnID);

            modelBuilder.Entity<tbl_benhAn>()
                .HasMany(e => e.tbl_thongTinTruyVet)
                .WithRequired(e => e.tbl_benhAn)
                .HasForeignKey(e => e.benhAnID);

            modelBuilder.Entity<tbl_benhNhan>()
                .HasMany(e => e.tbl_benhAn)
                .WithRequired(e => e.tbl_benhNhan)
                .HasForeignKey(e => e.benhNhanID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_benhVien>()
                .HasMany(e => e.tbl_phongBenh)
                .WithRequired(e => e.tbl_benhVien)
                .HasForeignKey(e => e.benhVienID);

            modelBuilder.Entity<tbl_diaChi>()
                .HasMany(e => e.tbl_benhVien)
                .WithRequired(e => e.tbl_diaChi)
                .HasForeignKey(e => e.diaChiID);

            modelBuilder.Entity<tbl_diaChi>()
                .HasMany(e => e.tbl_nguoi)
                .WithRequired(e => e.tbl_diaChi)
                .HasForeignKey(e => e.diaChiID);

            modelBuilder.Entity<tbl_diaChi>()
                .HasMany(e => e.tbl_thongTinTruyVet)
                .WithRequired(e => e.tbl_diaChi)
                .HasForeignKey(e => e.diaChiID);

            modelBuilder.Entity<tbl_huyen>()
                .HasMany(e => e.tbl_xa)
                .WithRequired(e => e.tbl_huyen)
                .HasForeignKey(e => e.huyenID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_loaiPhong>()
                .HasMany(e => e.tbl_phongBenh)
                .WithRequired(e => e.tbl_loaiPhong)
                .HasForeignKey(e => e.loaiPhongID);

            modelBuilder.Entity<tbl_nguoi>()
                .HasOptional(e => e.tbl_benhNhan)
                .WithRequired(e => e.tbl_nguoi);

            modelBuilder.Entity<tbl_nguoi>()
                .HasOptional(e => e.tbl_nguoiDung)
                .WithRequired(e => e.tbl_nguoi);

            modelBuilder.Entity<tbl_nguoi>()
                .HasOptional(e => e.tbl_nhanVienYTe)
                .WithRequired(e => e.tbl_nguoi);

            modelBuilder.Entity<tbl_nhanVienYTe>()
                .HasMany(e => e.tbl_thongTinDieuTri)
                .WithRequired(e => e.tbl_nhanVienYTe)
                .HasForeignKey(e => e.nhanVienYTeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_phongBenh>()
                .HasMany(e => e.tbl_benhAn)
                .WithOptional(e => e.tbl_phongBenh)
                .HasForeignKey(e => e.phongBenhID);

            modelBuilder.Entity<tbl_tinh>()
                .HasMany(e => e.tbl_huyen)
                .WithRequired(e => e.tbl_tinh)
                .HasForeignKey(e => e.tinhID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_trangThai>()
                .HasMany(e => e.tbl_benhAn)
                .WithRequired(e => e.tbl_trangThai)
                .HasForeignKey(e => e.trangThaiID);

            modelBuilder.Entity<tbl_viTriLamViec>()
                .HasMany(e => e.tbl_nguoiDung)
                .WithRequired(e => e.tbl_viTriLamViec)
                .HasForeignKey(e => e.viTriLamViecID);

            modelBuilder.Entity<tbl_viTriLamViec>()
                .HasMany(e => e.tbl_nhanVienYTe)
                .WithRequired(e => e.tbl_viTriLamViec)
                .HasForeignKey(e => e.viTriLamViecID);

            modelBuilder.Entity<tbl_xa>()
                .HasMany(e => e.tbl_diaChi)
                .WithRequired(e => e.tbl_xa)
                .HasForeignKey(e => e.xaID);
        }
    }
}
