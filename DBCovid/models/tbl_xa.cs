namespace DBCovid.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_xa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_xa()
        {
            tbl_diaChi = new HashSet<tbl_diaChi>();
        }

        public int ID { get; set; }

        public string tenXa { get; set; }

        public string moTa { get; set; }

        public int huyenID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_diaChi> tbl_diaChi { get; set; }

        public virtual tbl_huyen tbl_huyen { get; set; }
    }
}
