namespace DBCovid.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_nguoiDung
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public string taiKhoan { get; set; }

        public string matKhau { get; set; }

        public int viTriLamViecID { get; set; }

        public virtual tbl_nguoi tbl_nguoi { get; set; }

        public virtual tbl_viTriLamViec tbl_viTriLamViec { get; set; }
    }
}
