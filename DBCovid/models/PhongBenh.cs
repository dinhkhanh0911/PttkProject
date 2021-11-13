using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCovid.models
{
    [Table("tbl_PhongBenhs")]
    public partial class PhongBenh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string tenPhong { get; set; }
        public int soGiuongToiDa { get; set; }
      
        public int soGiuongHienTai { get; set; }
        public int benhVienID { get; set; }
        public int? loaiPhongID { get; set; }
        [ForeignKey("benhVienID")]
        public virtual BenhVien benhVien { get; set; }
        [ForeignKey("loaiPhongID")]
        public virtual LoaiPhong loaiPhong { get; set; }

        public virtual IEnumerable<BenhAn> BenhAn { get; set; }
    }
}
