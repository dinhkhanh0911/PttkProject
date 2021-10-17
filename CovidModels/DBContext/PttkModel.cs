using PttkProject.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.dbContext
{
    public class PttkModel : DbContext
    {
        public PttkModel() : base("BenhNhanCovid")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<tbl_benhAn> tbl_benhAn { get; set; }
        public DbSet<tbl_benhNhan> tbl_benhNhan { get; set; }
        public DbSet<tbl_benhVien> tbl_benhVien { get; set; }
        public DbSet<tbl_diaChi> tbl_diaChi { get; set; }
        public DbSet<tbl_huyen> tbl_huyen { get; set; }
        public DbSet<tbl_loaiPhong> tbl_loaiPhong { get; set; }
        public DbSet<tbl_nguoi> tbl_nguoi { get; set; }
        public DbSet<tbl_nguoiDung> tbl_nguoiDung { get; set; }
        public DbSet<tbl_nhanVienYTe> tbl_nhanVienYTe { get; set; }
        public DbSet<tbl_phongBenh> tbl_phongBenh { get; set; }
        public DbSet<tbl_thongTinDieuTri> tbl_thongTinDieuTri { get; set; }
        public DbSet<tbl_thongTinTruyVet> tbl_thongTinTruyVet { get; set; }
        public DbSet<tbl_tinh> tbl_tinh { get; set; }
        public DbSet<tbl_trangThai> tbl_trangThai { get; set; }
        public DbSet<tbl_viTriLamViec> tbl_viTriLamViec { get; set; }
        public DbSet<tbl_xa> tbl_xa { get; set; }

    }
}

