using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CovidModels.models
{
    public class tbl_thongTinTruyVet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime thoiGian { get; set; }
        public string moTa { get; set; }
        public int benhAnID { get; set; }
        [ForeignKey("benhAnID")]
        public virtual tbl_benhAn benhAn { get; set; }
        public int diaChiID { get; set; }
        [ForeignKey("diaChiID")]
        public virtual tbl_diaChi diaChi {get;set;}
    }
}