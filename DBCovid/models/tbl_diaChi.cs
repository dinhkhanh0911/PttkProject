namespace DBCovid.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_diaChi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_diaChi()
        {
            tbl_benhVien = new HashSet<tbl_benhVien>();
            tbl_nguoi = new HashSet<tbl_nguoi>();
            tbl_thongTinTruyVet = new HashSet<tbl_thongTinTruyVet>();
        }

        public int ID { get; set; }

        public string chiTiet { get; set; }

        public string moTa { get; set; }

        public int xaID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_benhVien> tbl_benhVien { get; set; }

        public virtual tbl_xa tbl_xa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_nguoi> tbl_nguoi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_thongTinTruyVet> tbl_thongTinTruyVet { get; set; }
    }
}
