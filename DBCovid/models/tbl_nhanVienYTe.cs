namespace DBCovid.models
{
    using DBCovid.Abstact;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_nhanVienYTe:Nguoi
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public string chuyenKhoa { get; set; }

        public string bangCap { get; set; }

        public int namKinhNghiem { get; set; }

        public string moTa { get; set; }

        
    }
}
