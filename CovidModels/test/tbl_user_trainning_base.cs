namespace CovidModels.test
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_user_trainning_base
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

        [Column(TypeName = "datetime2")]
        public DateTime? from_date { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? to_date { get; set; }

        public long? training_base_id { get; set; }

        public long? user_id { get; set; }

        public virtual tbl_training_base tbl_training_base { get; set; }

        public virtual tbl_user tbl_user { get; set; }
    }
}
