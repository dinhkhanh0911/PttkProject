namespace DBCovid.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_benhNhan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_benhNhan()
        {
            tbl_benhAn = new HashSet<tbl_benhAn>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public string maBHYT { get; set; }

        public string sdtBenhNhan { get; set; }

        public string sdtNguoiThan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_benhAn> tbl_benhAn { get; set; }

        public virtual tbl_nguoi tbl_nguoi { get; set; }
    }
}
