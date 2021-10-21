using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CovidModels.models
{
    public class tbl_trangThai
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string tinhTrang { get; set; }
        public string moTa { get; set; }
        public virtual ICollection<tbl_benhAn> BenhAn { get; set; }
    }
}