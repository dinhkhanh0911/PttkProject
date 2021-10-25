namespace CovidModels.test
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_student_study_alert_level
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

        [StringLength(255)]
        public string note { get; set; }

        public int? status { get; set; }

        public long? semester_id { get; set; }

        public long? student_id { get; set; }

        public long? study_alert_condition_id { get; set; }

        public long? study_alert_level_id { get; set; }

        public virtual tbl_semester tbl_semester { get; set; }

        public virtual tbl_student tbl_student { get; set; }

        public virtual tbl_study_alert_level tbl_study_alert_level { get; set; }

        public virtual tbl_study_alert_condition tbl_study_alert_condition { get; set; }
    }
}
