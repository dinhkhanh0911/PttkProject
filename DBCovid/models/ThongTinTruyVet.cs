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
        public string diaChichiTiet { get; set; }
        public int xaID { get; set; }
        public int benhAnID { set; get; }
        public string moTa { get; set; }
        
        [ForeignKey("benhAnID")]
        public virtual BenhAn benhAn { get; set; }
        
        [ForeignKey("xaID")]
        public virtual Xa xa { get; set; }
        
    }
}
