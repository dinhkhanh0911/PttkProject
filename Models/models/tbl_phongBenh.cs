using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PttkProject.models
{
    public class tbl_phongBenh
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string tenPhong { get; set; }
        public int soGiuongToiDa { get; set; }
        public int soGiuongHienTai { get; set; }
        public int benhVienID { get; set; }
        [ForeignKey("benhVienID")]
        public virtual tbl_benhVien benhVien { get; set; }
        public int loaiPhongID { get; set; }
        [ForeignKey("loaiPhongID")]
        public virtual tbl_loaiPhong loaiPhong { get; set; }

        public virtual ICollection<tbl_benhAn> BenhAn { get; set; }

    }
}