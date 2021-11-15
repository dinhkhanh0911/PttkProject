using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCovid.models
{
    [Table("tbl_Huyen")]
    public partial class Huyen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string tenHuyen { get; set; }
        public string moTa { get; set; }
        public int code { get; set; }
        public int tinhID { get; set; }
        [ForeignKey("tinhID")]
        public virtual Tinh tinh { get; set; }
        public virtual IEnumerable<Xa> Xa { get; set; }
    }
}
