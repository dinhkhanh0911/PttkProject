using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCovid.models
{
    [Table("tbl_TrangThais")]
    public partial class TrangThai
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string tinhTrang { get; set; }
        public string moTa { get; set; }
        public virtual IEnumerable<BenhAn> BenhAn { get; set; }
    }
}
