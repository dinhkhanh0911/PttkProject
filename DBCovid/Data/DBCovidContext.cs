using DBCovid.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCovid.Data
{
    class DBCovidContext : DbContext
    {
        public DBCovidContext()
            : base("DBCovidContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        
        public virtual DbSet<BenhAn> benhAn { get; set; }
        public virtual DbSet<BenhNhan> benhNhan { get; set; }
        public virtual DbSet<BenhVien> benhVien { get; set; }
        public virtual DbSet<DiaChi> diaChi { get; set; }
        public virtual DbSet<Huyen> huyen { get; set; }
        public virtual DbSet<LoaiPhong> loaiPhong { get; set; }
        public virtual DbSet<NguoiDung> nguoiDung { get; set; }
        public virtual DbSet<NhanVienYTe> nhanVienYTe { get; set; }
        public virtual DbSet<PhongBenh> phongBenh { get; set; }
        public virtual DbSet<ThongTinDieuTri> thongtinDieuTri { get; set; }
        public virtual DbSet<ThongTinTruyVet> thongTinTruyVet { get; set; }
        public virtual DbSet<Tinh> tinh { get; set; }
        public virtual DbSet<TrangThai> trangThai { get; set; }
        public virtual DbSet<ViTriLamViec> viTriLamViec { get; set; }
        public virtual DbSet<Xa> xa { get; set; }
    }
}
