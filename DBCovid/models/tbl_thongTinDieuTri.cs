namespace DBCovid.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_thongTinDieuTri
    {
        public int ID { get; set; }

        public string gioPhut { get; set; }

        public DateTime ngay { get; set; }

        public string tinhTrangBenh { get; set; }

        public string yLenh { get; set; }

        public string moTa { get; set; }

        public int benhAnID { get; set; }

        public int nhanVienYTeID { get; set; }

        public virtual tbl_benhAn tbl_benhAn { get; set; }

        public virtual tbl_nhanVienYTe tbl_nhanVienYTe { get; set; }
    }
}
