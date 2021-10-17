using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PttkProject.models
{
    public class tbl_huyen
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string tenHuyen { get; set; }
        public string moTa { get; set; }
        public int tinhID { get; set; }
        [ForeignKey("tinhID")]
        public virtual tbl_tinh tinh { get; set; }
        public virtual ICollection<tbl_xa> Xa { get; set; }
        public virtual ICollection<tbl_diaChi> diaChi { get; set; }

    }
}