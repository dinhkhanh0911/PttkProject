using DBCovid.Abstact;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCovid.models
{
    [Table("tbl_DiaChis")]
    public partial class DiaChi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string chiTiet { get; set; }
        public string moTa { get; set; }
        public int xaID { get; set; }
        [ForeignKey("xaID")]
        public virtual Xa xa { get; set; }
        public virtual IEnumerable<BenhVien> benhVien { set; get; }
        public virtual IEnumerable<Nguoi> nguoi { set; get; }
        public virtual IEnumerable<ThongTinTruyVet> thongTinTruyVet { set; get; }
    }
}
