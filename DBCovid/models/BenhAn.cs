using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBCovid.models
{
    [Table("tbl_BenhAns")]
    public partial class BenhAn
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column(TypeName = "date")]
        
        public DateTime ngayNhapVien { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ngayXuatVien { get; set; }
        [StringLength(255)]
        public string chuanDoan { get; set; }
        [StringLength(255)]
        public string trieuChung { get; set; }
        [StringLength(255)]
        public string moTa { get; set; }
        
        public int benhNhanID { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Vui lòng chọn phòng bệnh"),]
        public int phongBenhID { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Vui lòng chọn trạng thái"),]
        public int trangThaiID { get; set; }

        [ForeignKey("trangThaiID")]
        public virtual TrangThai trangThai { get; set; }

        [ForeignKey("phongBenhID")]
        public virtual PhongBenh phongBenh { get; set; }

        [ForeignKey("benhNhanID")]
        public virtual BenhNhan benhNhan { get; set; }
        public virtual IEnumerable<ThongTinDieuTri> thongTinDieuTri { get; set; }
        public virtual IEnumerable<ThongTinTruyVet> thongTinTruyVet { get; set; }
    }
}
