namespace DBCovid.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_benhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_benhVien()
        {
            tbl_phongBenh = new HashSet<tbl_phongBenh>();
        }

        public int ID { get; set; }

        public string tenBenhVien { get; set; }

        public string moTa { get; set; }

        public int diaChiID { get; set; }

        public virtual tbl_diaChi tbl_diaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_phongBenh> tbl_phongBenh { get; set; }
    }
}
