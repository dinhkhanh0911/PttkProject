using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CovidModels.models
{
    public class tbl_thongTinDieuTri
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string gioPhut { get; set; }
        public DateTime ngay { get; set; }
        public string tinhTrangBenh { get; set; }
        public string yLenh { get; set; }
        public string moTa { get; set; }
        public int benhAnID { get; set; }
        [ForeignKey("benhAnID")]
        public virtual tbl_benhAn benhAn { get; set; }
        public int nhanVienYTeID { get; set; }
        [ForeignKey("nhanVienYTeID")]
        public virtual tbl_nhanVienYTe nhanVienYTe { get; set; }

    }
}