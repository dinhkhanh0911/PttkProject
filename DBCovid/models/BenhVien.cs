using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCovid.models
{
    [Table("tbl_BenhViens")]
    public partial class BenhVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string tenBenhVien { get; set; }
        public string diaChichiTiet { get; set; }
        public string moTa { get; set; }
        public int xaID { get; set; }
        [ForeignKey("xaID")]
        public virtual Xa xa { get; set; }
        public virtual IEnumerable<PhongBenh> PhongBenh { get; set; }
    }
}
