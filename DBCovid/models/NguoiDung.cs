using DBCovid.Abstact;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DBCovid.models
{
    
    [Table("Tbl_NguoiDungs")]
    public partial class NguoiDung:Nguoi
    {
        public string taiKhoan { get; set; }
        public string matKhau { get; set; }
        public string sdt { get; set; }
        public int viTriLamViecID { set; get; }
        [ForeignKey("viTriLamViecID")]
        public virtual ViTriLamViec viTriLamViec { get; set; }
    }
}
