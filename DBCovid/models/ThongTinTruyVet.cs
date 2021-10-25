using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCovid.models
{
    [Table("tbl_ThongTinTruyVets")]
    public partial class ThongTinTruyVet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column(TypeName ="Date")]
        public DateTime thoiGian { get; set; }
        public string moTa { get; set; }
        public int benhAnID { get; set; }
        [ForeignKey("benhAnID")]
        public virtual BenhAn benhAn { get; set; }
        public int diaChiID { get; set; }
        [ForeignKey("diaChiID")]
        public virtual DiaChi diaChi { get; set; }
    }
}
