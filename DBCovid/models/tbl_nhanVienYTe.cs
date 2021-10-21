namespace DBCovid.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_nhanVienYTe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_nhanVienYTe()
        {
            tbl_thongTinDieuTri = new HashSet<tbl_thongTinDieuTri>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public string chuyenKhoa { get; set; }

        public string bangCap { get; set; }

        public int namKinhNghiem { get; set; }

        public string moTa { get; set; }

        public int viTriLamViecID { get; set; }

        public virtual tbl_nguoi tbl_nguoi { get; set; }

        public virtual tbl_viTriLamViec tbl_viTriLamViec { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_thongTinDieuTri> tbl_thongTinDieuTri { get; set; }
    }
}
