namespace DBCovid.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_thongTinTruyVet
    {
        public int ID { get; set; }

        public DateTime thoiGian { get; set; }

        public string moTa { get; set; }

        public int benhAnID { get; set; }

        public int diaChiID { get; set; }

        public virtual tbl_benhAn tbl_benhAn { get; set; }

        public virtual tbl_diaChi tbl_diaChi { get; set; }
    }
}
