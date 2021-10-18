using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CovidModels.models
{
    [Table("tbl_nhanVienYTe")]
    public class tbl_nhanVienYTe :tbl_nguoi
    {
        public string chuyenKhoa { get; set; }
        public string bangCap { get; set; }
        public int namKinhNghiem { get; set; }
        public string moTa { get; set; }
        public int viTriLamViecID { get; set; }
        [ForeignKey("viTriLamViecID")]
        public virtual tbl_viTriLamViec viTriLamViec { get; set; }

        public virtual ICollection<tbl_thongTinDieuTri> ThongTinDieuTri { get; set; }


    }
}