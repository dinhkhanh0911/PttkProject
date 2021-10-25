using DBCovid.Abstact;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBCovid.models
{
    [Table("tbl_BenhNhans")]
    public partial class BenhNhan:Nguoi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        public string maBHYT { get; set; }
        public string sdtBenhNhan { get; set; }
        public string tenNguoiThan { set; get; }
        public string sdtNguoiThan { get; set; }
        [Required]
        public string doiTuongCachLy { get; set; }
        public virtual IEnumerable<BenhAn> BenhAn { get; set; }
    }
}
