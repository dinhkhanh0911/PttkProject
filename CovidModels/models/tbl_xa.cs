using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CovidModels.models
{
    public class tbl_xa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string tenXa { get; set; }
        public string moTa { get; set; }
        public int huyenID { get; set; }
        [ForeignKey("huyenID")]
        public virtual tbl_huyen huyen { get; set; }
        public virtual ICollection<tbl_diaChi> diaChi { get; set; }
    }
}