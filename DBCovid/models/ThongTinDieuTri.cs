using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCovid.models
{
    [Table("tbl_ThongTinDieuTris")]
    public partial class ThongTinDieuTri
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string gioPhut { get; set; }
        [Column(TypeName = "Date")]
        public DateTime ngay { get; set; }
        public string tinhTrangBenh { get; set; }
        public string yLenh { get; set; }
        public string moTa { get; set; }
        public int benhAnID { get; set; }
        [ForeignKey("benhAnID")]
        public virtual BenhAn benhAn { get; set; }
        public int nhanVienYTeID { get; set; }
        [ForeignKey("nhanVienYTeID")]
        public virtual NhanVienYTe nhanVienYTe { get; set; }
    }
}
