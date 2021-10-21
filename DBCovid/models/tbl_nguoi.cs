namespace DBCovid.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_nguoi
    {
        public int ID { get; set; }

        public string ten { get; set; }

        public DateTime ngaySinh { get; set; }

        [Required]
        public string CMND { get; set; }

        public string gioiTinh { get; set; }

        public int diaChiID { get; set; }

        public virtual tbl_benhNhan tbl_benhNhan { get; set; }

        public virtual tbl_diaChi tbl_diaChi { get; set; }

        public virtual tbl_nguoiDung tbl_nguoiDung { get; set; }

        public virtual tbl_nhanVienYTe tbl_nhanVienYTe { get; set; }
    }
}
