using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CovidModels.models
{
    public class tbl_benhAn
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column(TypeName = "datetime2")]
        [Required]
        public DateTime? ngayNhapVien { get; set; }
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

        [ForeignKey("trangThaiID")]
        public virtual tbl_trangThai trangThai { get; set; }

        [ForeignKey("phongBenhID")]
        public virtual tbl_phongBenh phongBenh { get; set; }

        [ForeignKey("benhNhanID")]
        public virtual tbl_benhNhan benhNhan { get; set; }
        public virtual ICollection<tbl_thongTinDieuTri> tbl_thongTinDieuTri { get; set; }
        public virtual ICollection<tbl_thongTinTruyVet> tbl_thongTinTruyVet { get; set; }
    }
}