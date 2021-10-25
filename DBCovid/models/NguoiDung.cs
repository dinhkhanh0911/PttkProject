using DBCovid.Abstact;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DBCovid.models
{
    
    [Table("Tbl_NguoiDungs")]
    public partial class NguoiDung:Nguoi
    {

        [Required]

        public string taiKhoan { get; set; }
        [Required]

        public string matKhau { get; set; }
        public int viTriLamViecID { set; get; }
        [ForeignKey("viTriLamViecID")]
        public virtual ViTriLamViec viTriLamViec { get; set; }
    }
}
