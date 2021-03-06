namespace CovidModels.test
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_test_bag
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_test_bag()
        {
            tbl_student_semester_subject_exam_room = new HashSet<tbl_student_semester_subject_exam_room>();
        }

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
        public string code { get; set; }

        public int? end_marking_code { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int? number_of_room { get; set; }

        public int? number_student { get; set; }

        public int? start_marking_code { get; set; }

        public long? semester_subject_exam_id { get; set; }

        public long? test_bag_create_time_id { get; set; }

        public virtual tbl_semester_subject_exam tbl_semester_subject_exam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_student_semester_subject_exam_room> tbl_student_semester_subject_exam_room { get; set; }

        public virtual tbl_testBag_create_time tbl_testBag_create_time { get; set; }
    }
}
