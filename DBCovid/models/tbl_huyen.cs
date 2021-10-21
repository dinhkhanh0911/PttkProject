namespace DBCovid.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_huyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_huyen()
        {
            tbl_xa = new HashSet<tbl_xa>();
        }

        public int ID { get; set; }

        public string tenHuyen { get; set; }

        public string moTa { get; set; }

        public int tinhID { get; set; }

        public virtual tbl_tinh tbl_tinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_xa> tbl_xa { get; set; }
    }
}
