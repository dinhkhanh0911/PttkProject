using DBCovid.Abstact;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DBCovid.models
{
    [Table("tbl_Xa")]
    public partial class Xa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string tenXa { get; set; }
        public string moTa { get; set; }
        public int code { get; set; }
        public int huyenID { get; set; }
        [ForeignKey("huyenID")]
        public virtual Huyen huyen { get; set; }
        public virtual IEnumerable<Nguoi> nguoi { get; set; }
        public virtual IEnumerable<BenhVien> benhVien { get; set; }
        public virtual IEnumerable<ThongTinTruyVet> thongTinTruyVet { get; set; }
    }
}
