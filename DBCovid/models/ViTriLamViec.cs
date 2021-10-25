using DBCovid.Abstact;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DBCovid.models
{
        
    [Table("tbl_ViTriLamViecs")]
    public partial class ViTriLamViec
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string tenViTri { get; set; }
        public string moTa { get; set; }
        public virtual IEnumerable<NguoiDung> nguoiDung { get; set; }
        public virtual IEnumerable<NhanVienYTe> nhanVienYTe { get; set; }

    }
}
