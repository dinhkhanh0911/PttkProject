using DBCovid.Abstact;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DBCovid.models
{
    
    [Table("Tbl_NhanVienYTes")]
    public partial class NhanVienYTe:Nguoi
    {
        public string chuyenKhoa { get; set; }

        public string bangCap { get; set; }
        public string sdt { get; set; }
        public int namKinhNghiem { get; set; }
        public int viTriLamViecID { set; get; }
        [ForeignKey("viTriLamViecID")]
        public virtual ViTriLamViec viTriLamViec { get; set; }
        public virtual IEnumerable<ThongTinDieuTri> thongTinDieuTri { set; get; }


    }
}
