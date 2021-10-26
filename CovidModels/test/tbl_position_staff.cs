namespace CovidModels.test
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_position_staff
    {
        public long id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime create_date { get; set; }

        [Required]
        [StringLength(100)]
        public string created_by { get; set; }

        [StringLength(100)]
        public string modified_by { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? modify_date { get; set; }

        [StringLength(255)]
        public string uuid_key { get; set; }

        public bool? voided { get; set; }

        public bool? current_position { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? from_date { get; set; }

        public bool? main_position { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? to_date { get; set; }

        public long? department_id { get; set; }

        public long? position_id { get; set; }

        public long? staff_id { get; set; }

        public virtual tbl_department tbl_department { get; set; }

        public virtual tbl_position_title tbl_position_title { get; set; }

        public virtual tbl_staff tbl_staff { get; set; }
    }
}