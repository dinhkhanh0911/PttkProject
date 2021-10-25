using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCovid.models
{
    [Table("tbl_Tinhs")]
    public partial class Tinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string tenTinh { get; set; }
        public string moTa { get; set; }
        public virtual IEnumerable<Huyen> Huyen { get; set; }
    }
}
