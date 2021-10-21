namespace DBCovid.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_benhAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_benhAn()
        {
            tbl_thongTinDieuTri = new HashSet<tbl_thongTinDieuTri>();
            tbl_thongTinTruyVet = new HashSet<tbl_thongTinTruyVet>();
        }

        public int ID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ngayNhapVien { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ngayXuatVien { get; set; }

        [StringLength(255)]
        public string chuanDoan { get; set; }

        [StringLength(255)]
        public string trieuChung { get; set; }

        [StringLength(255)]
        public string moTa { get; set; }

        public int benhNhanID { get; set; }

        public int? phongBenhID { get; set; }

        public int trangThaiID { get; set; }

        public virtual tbl_benhNhan tbl_benhNhan { get; set; }

        public virtual tbl_phongBenh tbl_phongBenh { get; set; }

        public virtual tbl_trangThai tbl_trangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_thongTinDieuTri> tbl_thongTinDieuTri { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_thongTinTruyVet> tbl_thongTinTruyVet { get; set; }
    }
}
