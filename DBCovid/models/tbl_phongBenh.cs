namespace DBCovid.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_phongBenh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_phongBenh()
        {
            tbl_benhAn = new HashSet<tbl_benhAn>();
        }

        public int ID { get; set; }

        public string tenPhong { get; set; }

        public int soGiuongToiDa { get; set; }

        public int soGiuongHienTai { get; set; }

        public int benhVienID { get; set; }

        public int loaiPhongID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_benhAn> tbl_benhAn { get; set; }

        public virtual tbl_benhVien tbl_benhVien { get; set; }

        public virtual tbl_loaiPhong tbl_loaiPhong { get; set; }
    }
}
