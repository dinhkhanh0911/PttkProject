using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CovidModels.models
{
    public class tbl_benhVien
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string tenBenhVien { get; set; }
        public string moTa { get; set; }
        public int diaChiID { get; set; }
        [ForeignKey("diaChiID")]
        public virtual tbl_diaChi diaChi { get; set; }
        public virtual ICollection<tbl_phongBenh> PhongBenh { get; set; }
    }
}